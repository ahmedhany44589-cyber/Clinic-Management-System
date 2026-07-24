using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ClinicManagementSystem.Domain.Comman;
using ClinicManagementSystem.Domain.Interfaces;
using ClinicManagementSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        public Repository(ApplicationDbContext _context)
        {
            this._context = _context;
        }
        public async  Task AddAsync(T obj)
        {
            await _context.Set<T>().AddAsync(obj);
        }

        public async Task Delete(T obj)
        {
            
            obj.IsDeleted = true;
            obj.UpdatedAt = DateTime.UtcNow;
            _context.Update(obj);
            
        }
        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
          return  await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdasync(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Updtae(T obj)
        {
            _context.Set<T>().Update(obj);
        }
    }
}
