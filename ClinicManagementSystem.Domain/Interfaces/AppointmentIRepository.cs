using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagementSystem.Domain.Entities;

namespace ClinicManagementSystem.Domain.Interfaces
{
    public interface AppointmentIRepository : IRepository<Appointment>
    {
        Task<(IEnumerable<Appointment> Items, int TotalCount)> GetPagedWithDetailsAsync(int pageNumber, int pageSize);
        Task<Appointment> GetByIdWithDetailsAsync(int id);

    }
}
