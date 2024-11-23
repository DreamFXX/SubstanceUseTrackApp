using System.Data;
using System.Data.SQLite;
using Dapper;
using Spectre.Console;


public class DatabaseManager
{
    private string _connectionString = "";

    public DatabaseManager (string connectionString)
    {
        _connectionString = connectionString;
        using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
            InitSubstanceTable(connection);
            AnsiConsole.MarkupLine($"[grey]- Sucessfully created: {_connectionString} database.[/]");
            AnsiConsole.MarkupLine("");
        }
        
    }

    void InitSubstanceTable(SQLiteConnection connection)
    {
        connection.Execute(
            @"CREATE TABLE IF NOT EXISTS SubstancesData (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Substance TEXT NOT NULL,
                DoseAmount REAL NOT NULL,
                Unit TEXT NOT NULL,
                DateTime TEXT NOT NULL
            )"
                );
        }
    }
