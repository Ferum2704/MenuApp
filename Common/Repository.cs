using Common.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Repository<T>:IRepository<T> where T:class
    {
        private readonly IDapperContext _context;
        public Repository(IDapperContext context)
        {
            _context = context;
        }
        public async Task<T> GetById(int id)
        {
            var query = "SELECT * FROM " + typeof(T).Name + "WHERE Id = @id";
            using (var connection = _context.CreateConnection())
            {
                var menuItem = await connection.QueryFirstOrDefaultAsync<T>(query, new { id });
                return menuItem;
            }

        }
        public async Task<IEnumerable<T>> GetAll()
        {
            var query = "SELECT * FROM " + typeof(T).Name;
            using (var connection = _context.CreateConnection())
            {
                var menuItemList = await connection.QueryAsync<T>(query);
                return menuItemList;
            }
        }
    }
}
