using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.Sqlite;
using Dapper;
using Z.Dapper.Plus;

class DatabaseManager
{
    private string _connectionString = "";
    public DatabaseManager(string connectionString)
    {
        _connectionString = connectionString;
        
    }


}

