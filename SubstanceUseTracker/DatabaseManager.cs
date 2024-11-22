using System.Data;
using System.Data.SQLite;
using Dapper;

class DatabaseManager
{
    private string _connectionString = "";
    public DatabaseManager(string connectionString)
    {
        _connectionString = connectionString;
        // ! -> SqlMapper.AddTypeHandler(new TimeSpanHandler());
    }


}

