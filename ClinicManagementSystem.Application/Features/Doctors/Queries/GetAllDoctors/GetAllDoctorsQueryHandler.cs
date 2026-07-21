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
            var AllDoctors = await unit.Doctor.GetAllAsync();
            var totalcount = AllDoctors.Count();
            var PagedDoctors = AllDoctors.Skip((request.PageNumber-1)*request.PageSize).Take(request.PageSize).ToList();
            var DoctorsDto = mapper.Map<List<DoctorDto>>(PagedDoctors);
            return new PaginatedResult<DoctorDto>()
            {
                Items = DoctorsDto,
                TotalCount = totalcount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
            };
        }
    }
}
