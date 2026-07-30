using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClinicManagementSystem.Domain.Interfaces;
using MediatR;

namespace ClinicManagementSystem.Application.Features.Appointments.Commands.UpdateAppointment
{
    public class UpdateAppointmentCommandHandler(IUnitOfWork unit, IMapper mapper) : IRequestHandler<UpdateAppointmentCommand, bool>
    {
        public async Task<bool> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = await unit.Appointment.GetByIdWithDetailsAsync(request.Id);
            if (appointment == null) return false;
            mapper.Map(request, appointment);
            unit.Appointment.Updtae(appointment);
            await unit.SaveChangesAsync();
            return true;
        }
    }
}
