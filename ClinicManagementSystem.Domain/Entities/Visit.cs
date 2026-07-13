using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagementSystem.Domain.Comman;

namespace ClinicManagementSystem.Domain.Entities
{
    public class Visit : BaseEntity
    {
        public string Diagnosis { get; set; }
        public DateTime VisitDate { get; set; }
        public string? Notes { get; set; }
        [ForeignKey("appointment")]
        public int AppointmentId { get; set; }
        public Appointment appointment { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
        public ICollection<LabResult> LabResults { get; set; } = new List<LabResult>();
        public Invoice invoice { get; set; }

    }
}
