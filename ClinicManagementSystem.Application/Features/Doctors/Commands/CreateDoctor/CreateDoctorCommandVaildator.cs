using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Validators;


namespace ClinicManagementSystem.Application.Features.Doctors.Commands.CreateDoctor
{
    public class CreateDoctorCommandVaildator : AbstractValidator<CreateDoctorCommand>
    {
        public CreateDoctorCommandVaildator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("اسم الدكتور مطلوب")
                .MaximumLength(100).WithMessage("اسم الدكتور يجب ألا يتجاوز 100 حرف");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("رقم الهاتف مطلوب")
                .Matches(@"^01[0-2,5]{1}[0-9]{8}$").WithMessage("رقم الهاتف غير صالح");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("البريد الإلكتروني غير صالح")
                .When(x => !string.IsNullOrEmpty(x.Email));

            RuleFor(x => x.ConsultationFees)
                .GreaterThan(0).WithMessage("سعر الكشف يجب أن يكون أكبر من صفر");

           
        }
    }
}
