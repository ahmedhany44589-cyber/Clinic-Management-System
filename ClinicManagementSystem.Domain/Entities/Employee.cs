using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagementSystem.Domain.Comman;

namespace ClinicManagementSystem.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public string? Email { get; set; }
        [ForeignKey("department")]
        public int DepartmentId { get; set; }
        public Department department { get; set; }

        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
        public ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();
    }
}
