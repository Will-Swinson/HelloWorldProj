using System.Data;
using System.Data.Common;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HelloWorld.Data
{
  class DapperContext
  {
    private string? _connectionString;

    public DapperContext(IConfiguration config)
    {
      _connectionString = config.GetConnectionString("DefaultConnection");
    }

    public IEnumerable<T> LoadData<T>(string sql)
    {
      IDbConnection dbConnection = new SqlConnection(_connectionString);
      return dbConnection.Query<T>(sql);

    }
    public T LoadDataSingle<T>(string sql)
    {
      IDbConnection dbConnection = new SqlConnection(_connectionString);
      return dbConnection.QuerySingle<T>(sql);

    }
    public bool Execute(string sql)
    {
      IDbConnection dbConnection = new SqlConnection(_connectionString);
      return (dbConnection.Execute(sql) > 0);

    }
     public int ExecuteWithRowCount(string sql)
    {
      IDbConnection dbConnection = new SqlConnection(_connectionString);
      return dbConnection.Execute(sql);

    }
  }
}