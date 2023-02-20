using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IRepository<T>where T : class
    {
        public Task<T> GetByIdAsync(Guid id);
        public Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<Guid> ids);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> AddAsync(T entity);
        public Task AddRange(IEnumerable<T> entities); 
        public Task Delete(Guid id);
    }
}
