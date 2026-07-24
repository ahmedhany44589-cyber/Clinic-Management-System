using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClinicManagementSystem.Domain.Entities;
using ClinicManagementSystem.Domain.Interfaces;
using MediatR;

namespace ClinicManagementSystem.Application.Features.Doctors.Commands.CreateDoctor
{
    public class CreateDoctorCommandHandler(IUnitOfWork unit , IMapper mapper) : IRequestHandler<CreateDoctorCommand, int>
    {
        public async Task<int> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            var des = mapper.Map<Doctor>(request);
            await unit.Doctors.AddAsync(des);
            await unit.SaveChangesAsync();
            return des.Id;
        }
    }
}
