using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClinicManagementSystem.Domain.Interfaces;
using MediatR;

namespace ClinicManagementSystem.Application.Features.Appointments.Commands.DeleteAppointment
{
    public class DeleteAppointmentCommandHandler(IUnitOfWork unit, IMapper mapper) : IRequestHandler<DeleteAppointmentCommand, bool>

    {
        public async Task<bool> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = await unit.Appointment.GetByIdWithDetailsAsync(request.Id);
            if (appointment == null) { 
            return false;
            }
            unit.Appointment.Delete(appointment);
            await unit.SaveChangesAsync();
            return true;
        }
    }
}
