using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagementSystem.Domain.Comman;

namespace ClinicManagementSystem.Domain.Entities
{
    public class PrescriptionItem : BaseEntity
    {
        [ForeignKey("prescription")]
        public int PrescriptionId { get; set; }
        public Prescription prescription { get; set; }
        public string MedicineName { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
        public string Duration { get; set; }
        public string? Instruction { get; set; }
    }
}
