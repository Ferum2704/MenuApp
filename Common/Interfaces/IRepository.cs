﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IRepository<T>where T : class
    {
        public Task<T> AddAsync(T entity);
        public Task<T> GetByIdAsync(Guid id);
        public Task<IEnumerable<T>> GetAllAsync();
    }
}
