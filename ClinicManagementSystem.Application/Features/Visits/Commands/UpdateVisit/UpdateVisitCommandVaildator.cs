using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagementSystem.Domain.Entities;
using FluentValidation;

namespace ClinicManagementSystem.Application.Features.Visits.Commands.UpdateVisit
{
    public class UpdateVisitCommandVaildator : AbstractValidator<UpdateVisitCommand>
    {
        public UpdateVisitCommandVaildator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("معرف الزيارة غير صالح");

            RuleFor(x => x.AppointmentId)
                .GreaterThan(0).WithMessage("يجب تحديد الموعد المرتبط بالزيارة");

            RuleFor(x => x.Diagnosis)
                .NotEmpty().WithMessage("التشخيص مطلوب")
                .MaximumLength(500).WithMessage("التشخيص طويل جدًا");

            RuleFor(x => x.VisitDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("تاريخ الزيارة لا يمكن أن يكون في المستقبل");
        }
    }
}
