using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagementSystem.Domain.Entities;
using ClinicManagementSystem.Domain.Interfaces;
using ClinicManagementSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens.Experimental;

namespace ClinicManagementSystem.Infrastructure.Repositories
{
    public class AppointmentRepository : Repository<Appointment> , AppointmentIRepository
    {
        private readonly ApplicationDbContext _context;
        public AppointmentRepository(ApplicationDbContext _context) : base(_context)
        {
            this._context = _context;
        }

        

        public async Task<Appointment> GetByIdWithDetailsAsync(int id)
        {
            return await _context.Appointments.Include(p => p.patient).Include(d=>d.doctor)
                .FirstOrDefaultAsync(a=>a.Id==id);
        }

        public async Task<(IEnumerable<Appointment> Items, int TotalCount)> GetPagedWithDetailsAsync(int pageNumber, int pageSize)
        {
            IQueryable<Appointment> query = _context.Appointments.Include(p => p.patient).Include(d => d.doctor);
            var totalCount= query.Count();
            var items=await query.Skip((pageNumber-1)*pageSize).Take(pageSize).ToListAsync();
            return (items, totalCount);
        }
    }
}
