using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClinicManagementSystem.Application.DTOs;
using ClinicManagementSystem.Domain.Interfaces;
using MediatR;

namespace ClinicManagementSystem.Application.Features.Appointments.Queries.GetById
{
    public class GetByIdAppointmentQueryHandler(IUnitOfWork unit, IMapper mapper) : IRequestHandler<GetByIdAppointmentQuery, AppointmentDto>
    {
        public async Task<AppointmentDto> Handle(GetByIdAppointmentQuery request, CancellationToken cancellationToken)
        {
            var Appointment = await unit.Appointment.GetByIdWithDetailsAsync(request.Id);
            if (Appointment == null) { 
            throw new Exception("Appointment Not Found");
            }
            var appointmentdto = mapper.Map<AppointmentDto>(Appointment);
            return appointmentdto;

        }
    }
}
