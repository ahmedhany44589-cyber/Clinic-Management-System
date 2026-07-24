using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace ClinicManagementSystem.Application.Features.Patients.Commands.UpdatePatient
{
    public class UpdatePatientCommandValidator : AbstractValidator<UpdatePatientCommand>
    {
        public UpdatePatientCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("اسم المريض مطلوب")
                .MaximumLength(100).WithMessage("اسم المريض يجب ألا يتجاوز 100 حرف");

            RuleFor(x => x.NationalId)
                .NotEmpty().WithMessage("الرقم القومي مطلوب")
                .Length(14).WithMessage("الرقم القومي يجب أن يكون 14 رقمًا");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("رقم الهاتف مطلوب")
                .Matches(@"^01[0125][0-9]{8}$").WithMessage("رقم الهاتف غير صالح");

            RuleFor(x => x.DateOfBirth)
                .LessThan(DateTime.Now).WithMessage("تاريخ الميلاد يجب أن يكون في الماضي");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("البريد الإلكتروني غير صالح")
                .When(x => !string.IsNullOrEmpty(x.Email));
        }
    }
}
