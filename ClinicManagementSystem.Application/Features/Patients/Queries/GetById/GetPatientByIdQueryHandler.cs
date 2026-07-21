using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClinicManagementSystem.Application.DTOs;
using ClinicManagementSystem.Domain.Interfaces;
using MediatR;

namespace ClinicManagementSystem.Application.Features.Patients.Queries.GetById
{
    public class GetPatientByIdQueryHandler(IUnitOfWork unit , IMapper mapper) : IRequestHandler<GetPatientByIdQuery, PatientDto>
    {
        public async Task<PatientDto> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            var Patient = await unit.Patients.GetByIdasync(request.Id);
            var PatientDto = mapper.Map<PatientDto>(Patient);
            return PatientDto;
        }
    }
}
