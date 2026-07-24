using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClinicManagementSystem.Application.Common.Models;
using ClinicManagementSystem.Application.DTOs;
using ClinicManagementSystem.Domain.Interfaces;
using MediatR;

namespace ClinicManagementSystem.Application.Features.Doctors.Queries.GetAllDoctors
{
    public class GetAllDoctorsQueryHandler (IUnitOfWork unit , IMapper mapper): IRequestHandler<GetAllDoctorsQuery, PaginatedResult<DoctorDto>>
    {
        public async Task<PaginatedResult<DoctorDto>> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
        {
            var (Doctors, totalCount) = await unit.Doctors.GetPagedWithSpecializationAsync(request.PageNumber, request.PageSize);
            
            var DoctorsDto = mapper.Map<List<DoctorDto>>(Doctors);
            return new PaginatedResult<DoctorDto>()
            {
                Items = DoctorsDto,
                TotalCount = totalCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
            };
        }
    }
}
