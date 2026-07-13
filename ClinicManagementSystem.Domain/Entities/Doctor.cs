using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagementSystem.Domain.Comman;

namespace ClinicManagementSystem.Domain.Entities
{
    public class Doctor : BaseEntity
    {
        public string Name { get; set; } = null;
        public string Phone {  get; set; } = null;
        public string Email { get; set; } = null;
        public decimal ConsultationFees { get; set; }
        [ForeignKey("Specialization")]
        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }
        public ICollection<Appointment> appointments { get; set; }
    }
}
