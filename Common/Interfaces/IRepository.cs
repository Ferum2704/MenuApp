using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IRepository<T>where T : class
    {
        public Task<T> GetById(int id);
        public Task<IEnumerable<T>> GetAll();
    }
}
