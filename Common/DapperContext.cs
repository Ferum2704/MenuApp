using Common.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Common
{
    public class DapperContext : IDapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _defaultConnection;
        private readonly string _masterConnection;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _defaultConnection = _configuration.GetConnectionString("DefaultConnection");
            _masterConnection = _configuration.GetConnectionString("MasterConnection");
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_defaultConnection);

        public IDbConnection CreateMasterConnection()
            => new SqlConnection(_masterConnection);
    }
}
