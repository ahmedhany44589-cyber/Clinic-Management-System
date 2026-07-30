using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClinicManagementSystem.Application.DTOs;
using ClinicManagementSystem.Domain.Entities;
using ClinicManagementSystem.Domain.Enums;
using ClinicManagementSystem.Domain.Interfaces;
using MediatR;

namespace ClinicManagementSystem.Application.Features.Appointments.Commands.CreateAppointment
{
    public class CreateAppointmentCommandHandler(IUnitOfWork unit , IMapper mapper) : IRequestHandler<CreateAppointmentCommand, int>
    {
       
        async Task<int> IRequestHandler<CreateAppointmentCommand, int>.Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var des = mapper.Map<Appointment>(request);
            des.Status=AppointmentStatus.Pending;
            await unit.Appointment.AddAsync(des);
            await unit.SaveChangesAsync();
            return des.Id;
        }
    }
}
