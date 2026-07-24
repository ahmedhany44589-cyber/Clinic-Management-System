using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagementSystem.Domain.Entities;
using ClinicManagementSystem.Domain.Interfaces;
using ClinicManagementSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem.Infrastructure.Repositories
{
    public class DoctorRepository : Repository<Doctor>, DoctorIRepository
    {
        private readonly ApplicationDbContext _context;

        public DoctorRepository(ApplicationDbContext _context):base(_context) { 
        this._context = _context;
        }

        public async Task<Doctor> GetByIdWithSpecializationAsync(int id)
        {
            return await _context.Doctors
                 .Include(d => d.Specialization)
                    .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<(IEnumerable<Doctor> items, int TotalCount)> GetPagedWithSpecializationAsync(int PageNumber, int PageSize)
        {
            IQueryable<Doctor> query = _context.Doctors.Include(s => s.Specialization);
            var totalcount =await query.CountAsync();
            var items = await query.Skip((PageNumber-1) * PageSize).Take(PageSize).ToListAsync();
            return (items, totalcount);
        }
    }
}
