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

namespace ClinicManagementSystem.Application.Features.Patients.Queries
{
    public class GetAllPatientQueryHandler(IUnitOfWork unit,IMapper mapper) : IRequestHandler<GetAllPatientQuery, PaginatedResult<PatientDto>>
    {
      

        async Task<PaginatedResult<PatientDto>> IRequestHandler<GetAllPatientQuery, PaginatedResult<PatientDto>>.Handle(GetAllPatientQuery request, CancellationToken cancellationToken)
        {
            var AllPatients = await unit.Patients.GetAllAsync();
           var TotalCount =AllPatients.Count();
            var pagedPatients = AllPatients
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();
            var patientsDtos=mapper.Map<List<PatientDto>>(pagedPatients);

            return new PaginatedResult<PatientDto>
            {
                Items = patientsDtos,
                TotalCount = TotalCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
            };

        }
    }
}
