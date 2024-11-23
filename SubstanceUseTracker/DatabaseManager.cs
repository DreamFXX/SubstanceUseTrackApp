using System.Data;
using System.Data.SQLite;
using Dapper;

class DatabaseManager
{
    private string _connectionString = "";
    public DatabaseManager(string connectionString)
    {
        
        _connectionString = connectionString;

        using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
        {

            connection.Execute(@"CREATE TABLE IF NOT EXISTS database (
                               Id INTEGER PRIMARY KEY AUTOINCREMENT,
                               Substance TEXT,
                               DoseAmount TEXT,
                               Unit TEXT,
                               DateTime TEXT
                               )");

        }
    }
}

