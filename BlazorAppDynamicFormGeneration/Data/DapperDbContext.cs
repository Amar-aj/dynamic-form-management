using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;

namespace BlazorAppDynamicFormGeneration.Data;

public class DapperDbContext(IConfiguration _configuration)
{
    public IDbConnection CreateConnection() => new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
    //public IDbConnection CreateConnection() => new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
}