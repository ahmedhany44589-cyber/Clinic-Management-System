using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagementSystem.Domain.Entities;

namespace ClinicManagementSystem.Domain.Interfaces
{
    public interface DoctorIRepository : IRepository<Doctor>
    {
        Task<(IEnumerable<Doctor> items, int TotalCount)> GetPagedWithSpecializationAsync(int PageNumber, int PageSize);
        Task<Doctor> GetByIdWithSpecializationAsync(int id);
    }
}
