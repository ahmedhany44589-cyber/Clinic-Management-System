using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClinicManagementSystem.Application.Common.Models;
using ClinicManagementSystem.Application.DTOs;
using ClinicManagementSystem.Domain.Entities;
using ClinicManagementSystem.Domain.Interfaces;
using MediatR;

namespace ClinicManagementSystem.Application.Features.Appointments.Queries.GetAllAppointments
{
    public class GetAllAppointmentsQueryHandler(IUnitOfWork unit, IMapper mapper) : IRequestHandler<GetAllAppointmentsQuery, PaginatedResult<AppointmentDto>>
    {
        public async Task<PaginatedResult<AppointmentDto>> Handle(GetAllAppointmentsQuery request, CancellationToken cancellationToken)
        {

            var (appointments, totalCount) = await unit.Appointment.GetPagedWithDetailsAsync(request.PageNumber, request.PageSize);
            var dtos = mapper.Map<List<AppointmentDto>>(appointments);
            return new PaginatedResult<AppointmentDto>
            {
                Items = dtos,
                TotalCount = totalCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };
        }
    }
}
