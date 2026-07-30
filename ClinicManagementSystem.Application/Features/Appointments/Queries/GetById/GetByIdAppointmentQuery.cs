using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagementSystem.Application.DTOs;
using MediatR;

namespace ClinicManagementSystem.Application.Features.Appointments.Queries.GetById
{
    public class GetByIdAppointmentQuery : IRequest<AppointmentDto>
    {
        public int  Id { get; set; }
    }
}
