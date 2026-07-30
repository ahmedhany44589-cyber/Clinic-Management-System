using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClinicManagementSystem.Domain.Interfaces;
using MediatR;

namespace ClinicManagementSystem.Application.Features.Visits.Commands.DeleteVisit
{
    public class DeleteVisitCommandHandler(IUnitOfWork unit, IMapper mapper) : IRequestHandler<DeleteVisitCommand, bool>
    {
        public async Task<bool> Handle(DeleteVisitCommand request, CancellationToken cancellationToken)
        {
            var visit = await unit.Visits.GetByIdWithDetailsAsync(request.Id);
            if (visit == null)
            {
                return false;
            }
            unit.Visits.Delete(visit);
            await unit.SaveChangesAsync();
            return true;
        }
    }
}
