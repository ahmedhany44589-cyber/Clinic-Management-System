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
    public class LabResult : BaseEntity
    {
        [ForeignKey("visit")]
        public int VisitId { get; set; }
        public Visit visit { get; set; }
        public string TestName { get; set; }
        public string? Result { get; set; }
        public LabResultStatus Status { get; set; }
    }
}
