using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagementSystem.Domain.Comman;
using ClinicManagementSystem.Domain.Enums;

namespace ClinicManagementSystem.Domain.Entities
{
    public class Appointment : BaseEntity
    {
      public DateTime AppointmentDate { get; set; }
        public AppointmentStatus Status { get; set; }
        public string? Notes { get; set; }
        public Visit Visit { get; set; }
        [ForeignKey("doctor")]
        public int DoctorId { get; set; }
        public Doctor doctor { get; set; }
        [ForeignKey("patient")]
        public int PatientId { get; set; }
        public Patient patient { get; set; }
    }
}
