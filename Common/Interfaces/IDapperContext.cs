using System.Data;

namespace Common.Interfaces
{
    public interface IDapperContext
    {
        IDbConnection CreateConnection();
        IDbConnection CreateMasterConnection();
    }
}