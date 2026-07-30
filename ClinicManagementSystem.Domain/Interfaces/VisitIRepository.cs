using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagementSystem.Domain.Entities;

namespace ClinicManagementSystem.Domain.Interfaces
{
    public interface VisitIRepository : IRepository<Visit>
    {
        Task<Visit?> GetByIdWithDetailsAsync(int id);
        Task<(IEnumerable<Visit> Items, int TotalCount)> GetPagedWithDetailsAsync(int pageNumber, int pageSize);
    }
}
