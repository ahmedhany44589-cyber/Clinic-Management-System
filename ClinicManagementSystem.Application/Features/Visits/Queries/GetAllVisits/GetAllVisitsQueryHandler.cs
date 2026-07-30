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

namespace ClinicManagementSystem.Application.Features.Visits.Queries.GetAllVisits
{
    public class GetAllVisitsQueryHandler(IUnitOfWork unit, IMapper mapper) : IRequestHandler<GetAllVisitsQuery, PaginatedResult<VisitDto>>
    {
        public async Task<PaginatedResult<VisitDto>> Handle(GetAllVisitsQuery request, CancellationToken cancellationToken)
        {
            var (visits,totalCount) = await unit.Visits.GetPagedWithDetailsAsync(request.PageNumber, request.PageSize);
            var dtos = mapper.Map<List<VisitDto>>(visits);
            return new PaginatedResult<VisitDto>
            {
                Items = dtos,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalCount = totalCount
            };
        }
    }
}
