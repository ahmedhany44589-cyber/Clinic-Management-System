using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagementSystem.Domain.Entities;
using ClinicManagementSystem.Domain.Enums;
using MediatR;

namespace ClinicManagementSystem.Application.Features.Patients.Commands.CreatePatient
{
    public class CreatePatientCommand :IRequest<int>
    {
        public string Name { get; set; }
        public string NationalId { get; set; }
        public Gender gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? BloodType { get; set; }
        
    }
}
