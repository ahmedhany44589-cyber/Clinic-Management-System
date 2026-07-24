using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagementSystem.Application.DTOs;
using MediatR;

namespace ClinicManagementSystem.Application.Features.Doctors.Queries.GetById
{
    public class GetDoctorByIdQuery : IRequest<DoctorDto>
    {
        public int Id { get; set; }
    }
}
