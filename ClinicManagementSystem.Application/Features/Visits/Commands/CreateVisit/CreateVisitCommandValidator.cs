using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace ClinicManagementSystem.Application.Features.Visits.Commands.CreateVisit
{
    public class CreateVisitCommandValidator : AbstractValidator<CreateVisitCommand>
    {
        public CreateVisitCommandValidator()
        {
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
