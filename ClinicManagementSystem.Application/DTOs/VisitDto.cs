using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Application.DTOs
{
    public class VisitDto
    {
        public int Id { get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
        public DateTime VisitDate { get; set; }
        public string Diagnosis { get; set; }
        public string? Notes { get; set; }
    }
}
