using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClinicManagementSystem.Application.DTOs;
using ClinicManagementSystem.Domain.Entities;
using ClinicManagementSystem.Domain.Interfaces;
using MediatR;

namespace ClinicManagementSystem.Application.Features.Doctors.Queries.GetById
{
    public class GetDoctorByIdQueryHandler(IUnitOfWork unit, IMapper mapper) : IRequestHandler<GetDoctorByIdQuery, DoctorDto>

    {
        public async Task<DoctorDto> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
        {
            var doctor = await unit.Doctors.GetByIdWithSpecializationAsync(request.Id);
            if (doctor == null)
            {
                return null;
            }
            var doctorDto= mapper.Map<DoctorDto>(doctor);
            return doctorDto;

        }
    }
}
