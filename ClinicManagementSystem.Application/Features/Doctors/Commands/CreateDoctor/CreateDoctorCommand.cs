using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagementSystem.Application.DTOs;
using MediatR;

namespace ClinicManagementSystem.Application.Features.Doctors.Commands.CreateDoctor
{
    public class CreateDoctorCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string? Email { get; set; }
        public decimal ConsultationFees { get; set; }

    }
}
