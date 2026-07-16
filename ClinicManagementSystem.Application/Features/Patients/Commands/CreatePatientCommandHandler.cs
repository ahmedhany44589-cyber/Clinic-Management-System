using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClinicManagementSystem.Domain.Entities;
using ClinicManagementSystem.Domain.Interfaces;
using MediatR;

namespace ClinicManagementSystem.Application.Features.Patients.Commands
{
    public class  CreatePatientCommandHandler(IUnitOfWork unit, IMapper mapper) : IRequestHandler<CreatePatientCommand, int>
    {
        public async Task<int> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            Patient Des = mapper.Map<Patient>(request);
           await unit.Patients.AddAsync(Des);
            await unit.SaveChangesAsync();
            return Des.Id;
        }
    }
}
