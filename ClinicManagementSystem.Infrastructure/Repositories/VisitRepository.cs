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
    public class VisitRepository : Repository<Visit>, VisitIRepository
    {
        private readonly ApplicationDbContext _context;
        public VisitRepository(ApplicationDbContext _context) : base(_context)
        {
            this._context = _context;
        }

        public async Task<Visit?> GetByIdWithDetailsAsync(int id)
        {
            return await _context.Visits.Include(A=>A.appointment).ThenInclude(D=>D.doctor).Include(A => A.appointment).ThenInclude(P=>P.patient).FirstOrDefaultAsync(v=>v.Id==id);
        }

        public async Task<(IEnumerable<Visit> Items, int TotalCount)> GetPagedWithDetailsAsync(int pageNumber, int pageSize)
        {
            IQueryable<Visit> query  = _context.Visits
                .Include(v => v.appointment)
                    .ThenInclude(a => a.doctor)
                .Include(v => v.appointment)
                    .ThenInclude(a => a.patient);
            var totalCount=await query.CountAsync();
            var items = await query
                 .Skip((pageNumber - 1) * pageSize)
                 .Take(pageSize)
                 .ToListAsync();
            return (items, totalCount);
        }
    }
}
