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
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
