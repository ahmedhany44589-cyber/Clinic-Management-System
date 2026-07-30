using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClinicManagementSystem.Domain.Entities;
using ClinicManagementSystem.Domain.Interfaces;
using MediatR;

namespace ClinicManagementSystem.Application.Features.Visits.Commands.CreateVisit
{
    public class CreateVisitCommandHandler(IUnitOfWork unit, IMapper mapper) : IRequestHandler<CreateVisitCommand, int>
    {
        public async Task<int> Handle(CreateVisitCommand request, CancellationToken cancellationToken)
        {
            var des = mapper.Map<Visit>(request);
            await unit.Visits.AddAsync(des);
            await unit.SaveChangesAsync();
            return des.Id;
        }
    }
}
