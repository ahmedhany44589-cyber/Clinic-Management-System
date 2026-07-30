using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace ClinicManagementSystem.Application.Features.Appointments.Commands.UpdateAppointment
{
    public class UpdateAppointmentCommandValidator : AbstractValidator<UpdateAppointmentCommand>
    {
        public UpdateAppointmentCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("معرف الموعد غير صالح");

            RuleFor(x => x.DoctorId)
                .GreaterThan(0).WithMessage("يجب اختيار الدكتور");

            RuleFor(x => x.PatientId)
                .GreaterThan(0).WithMessage("يجب اختيار المريض");

            RuleFor(x => x.AppointmentDate)
                .GreaterThan(DateTime.Now).WithMessage("موعد الحجز يجب أن يكون في المستقبل");
        }
    }
}
