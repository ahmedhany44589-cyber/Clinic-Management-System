using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagementSystem.Application.DTOs;
using MediatR;

namespace ClinicManagementSystem.Application.Features.Patients.Queries.GetById
{
    public class GetPatientByIdQuery : IRequest<PatientDto>
    {
        public int Id { get; set; }

    }
}
