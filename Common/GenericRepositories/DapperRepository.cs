using Common.Interfaces;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Common.GenericRepositories
{
    public class DapperRepository<T> : IDapperRepository<T> where T : class
    {
        protected readonly IDapperContext _context;
        public DapperRepository(IDapperContext context)
        {
            _context = context;
        }
        public async Task<T> GetByIdAsync(Guid id)
        {
            var query = "SELECT * FROM " + typeof(T).Name + "WHERE Id = @id";
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<T>(query, new { id });
                return result;
            }

        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var query = "SELECT * FROM " + typeof(T).Name;
            using (var connection = _context.CreateConnection())
            {
                var resultList = await connection.QueryAsync<T>(query);
                return resultList;
            }
        }

        public async Task<T> AddAsync(T entity)
        {
            using (var connection = _context.CreateConnection())
            {
                await connection.InsertAsync(entity);
                return entity;
            }
        }

        public async Task AddRange(IEnumerable<T> entities)
        {
            using (var connection = _context.CreateConnection())
            {
                await connection.InsertAsync(entities);
            }
        }
    }
}
