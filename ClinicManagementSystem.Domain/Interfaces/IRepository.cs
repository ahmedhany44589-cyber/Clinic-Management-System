using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ClinicManagementSystem.Domain.Comman;

namespace ClinicManagementSystem.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdasync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync (T obj);
        void Updtae (T obj);
        Task Delete(T obj);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

    }
}
