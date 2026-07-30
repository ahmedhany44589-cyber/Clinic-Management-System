using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ClinicManagementSystem.Application.Features.Visits.Commands.CreateVisit
{
    public class CreateVisitCommand : IRequest<int>
    {
        public int AppointmentId { get; set; }
        public DateTime VisitDate { get; set; }
        public string Diagnosis { get; set; }
        public string? Notes { get; set; }
    }
}
