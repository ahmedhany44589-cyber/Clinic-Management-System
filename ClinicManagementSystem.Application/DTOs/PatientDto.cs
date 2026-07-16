using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagementSystem.Domain.Enums;

namespace ClinicManagementSystem.Application.DTOs
{
    public class PatientDto
    {
        public int Id { get; set; }
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
