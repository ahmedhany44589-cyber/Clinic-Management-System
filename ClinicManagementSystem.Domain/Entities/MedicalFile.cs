using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagementSystem.Domain.Comman;

namespace ClinicManagementSystem.Domain.Entities
{
    public class MedicalFile : BaseEntity
    {
        public string? Allergies { get; set; }
        public string? ChronicDiseases { get; set; }
        public string? Notes { get; set; }
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
