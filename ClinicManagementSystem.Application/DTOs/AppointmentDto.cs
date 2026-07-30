using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagementSystem.Domain.Enums;

namespace ClinicManagementSystem.Application.DTOs
{
    public class AppointmentDto
    {
        public int Id { get; set; }

        public DateTime AppointmentDate { get; set; }

        public AppointmentStatus Status { get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
        public string? Notes { get; set; }

    }
}
