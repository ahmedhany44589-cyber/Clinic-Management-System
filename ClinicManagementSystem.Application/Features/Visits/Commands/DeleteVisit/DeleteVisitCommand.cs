using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ClinicManagementSystem.Application.Features.Visits.Commands.DeleteVisit
{
    public class DeleteVisitCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
