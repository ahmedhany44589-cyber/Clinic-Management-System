using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagementSystem.Application.Common.Models;
using ClinicManagementSystem.Application.DTOs;
using MediatR;

namespace ClinicManagementSystem.Application.Features.Patients.Queries.GetAllPatient
{
    public class GetAllPatientQuery : IRequest<PaginatedResult<PatientDto>>
    {
        public int PageNumber { get; set; } = 1;
            public int PageSize { get; set; } = 10;
    }
}
