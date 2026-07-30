using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClinicManagementSystem.Domain.Interfaces;
using MediatR;

namespace ClinicManagementSystem.Application.Features.Visits.Commands.UpdateVisit
{
    public class UpdateVisitCommandHandler(IUnitOfWork unit, IMapper mapper) : IRequestHandler<UpdateVisitCommand, bool>
    {
        public async Task<bool> Handle(UpdateVisitCommand request, CancellationToken cancellationToken)
        {
            var visit =await unit.Visits.GetByIdWithDetailsAsync(request.Id);
            if (visit == null)
            {
                return false;
            }
            mapper.Map(request,visit);
            unit.Visits.Updtae(visit);
            await unit.SaveChangesAsync();
            return true;

        }
    }
}
