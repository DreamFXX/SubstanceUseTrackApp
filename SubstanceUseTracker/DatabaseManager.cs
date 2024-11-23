using Microsoft.Extensions.FileProviders.Internal;
using Dapper;
using Z.Dapper.Plus;

class DatabaseManager
{
    private string _connectionString = "";
    public DatabaseManager(string connectionString)
    {
        
        _connectionString = connectionString;

        using (SqliteConnection connection = new SqliteConnection(_connectionString))
        {
            connection.Open();

            connection.Execute(
                @"CREATE TABLE IF NOT EXISTS SubstanceHabitData(
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Substance TEXT NOT NULL,
                DoseAmount DECIMAL(5,1),
                Unit TEXT NOT NULL,
                Date&Time TEXT NOT NULL,
                TotalAmountPerDay DECIMAL(5,1)");

        }
    }
}

