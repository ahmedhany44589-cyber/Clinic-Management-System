using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ClinicManagementSystem.Application.Features.Doctors.Commands.UpdateDoctor
{
    public class UpdateDoctorCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string? Email { get; set; }
        public decimal ConsultationFees { get; set; }
        public int SpecializationId { get; set; }
    }
}
