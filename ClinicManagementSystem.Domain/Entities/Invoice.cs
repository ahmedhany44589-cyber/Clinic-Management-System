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
    public class Invoice : BaseEntity
    {
        [ForeignKey("visit")]
        public int VisitId { get; set; }
        public Visit visit { get; set; }
        public decimal Amount { get; set; }
        public PaymentStatus Status { get; set; }
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
