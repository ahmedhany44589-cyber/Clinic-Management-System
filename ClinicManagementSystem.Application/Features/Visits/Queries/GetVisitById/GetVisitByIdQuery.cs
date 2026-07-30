using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagementSystem.Application.DTOs;
using MediatR;

namespace ClinicManagementSystem.Application.Features.Visits.Queries.GetVisitById
{
    public class GetVisitByIdQuery : IRequest<VisitDto>
    {
        public int Id { get; set; } 
    }
}
