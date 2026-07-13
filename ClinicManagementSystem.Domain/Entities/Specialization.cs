using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagementSystem.Domain.Comman;

namespace ClinicManagementSystem.Domain.Entities
{
    public class Specialization : BaseEntity
    {
        public string Name { get; set; } = null;
        public string? Description { get; set; }
        // nav prop
        public ICollection<Doctor> doctors { get; set; }
    }
}
