using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface ICosmosRepository<T>:IRepository<T> where T : class
    {
        Task<T> GetByPartitionKey(string partitionKeyValue);
    }
}
