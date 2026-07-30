using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClinicManagementSystem.Application.DTOs;
using ClinicManagementSystem.Domain.Interfaces;
using MediatR;

namespace ClinicManagementSystem.Application.Features.Visits.Queries.GetVisitById
{
    internal class GetVisitByIdQueryHandler(IUnitOfWork unit , IMapper mapper) : IRequestHandler<GetVisitByIdQuery, VisitDto>
    {
        public async Task<VisitDto> Handle(GetVisitByIdQuery request, CancellationToken cancellationToken)
        {
            var visit =  await unit.Visits.GetByIdWithDetailsAsync(request.Id);
            if (visit == null)
            {
                return null;
            }
            return mapper.Map<VisitDto>(visit);

        }
    }
}
