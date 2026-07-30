using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ClinicManagementSystem.Application.Features.Visits.Commands.UpdateVisit
{
    public class UpdateVisitCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public DateTime VisitDate { get; set; }
        public string Diagnosis { get; set; }
        public string? Notes { get; set; }

    }
}
