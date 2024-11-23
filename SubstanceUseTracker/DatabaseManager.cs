using System;
using System.Data.SQLite;
using Dapper;
using Z.Dapper.Plus.DapperPlusExpressionMapper;
using Spectre.Console;
using System.ComponentModel;
using System.Xml.Linq;

public class DatabaseManager
{
    private string _connectionString;

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
            @"CREATE TABLE IF NOT EXISTS Substances_Data (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Substance TEXT NOT NULL,
                DoseAmount REAL NOT NULL,
                Unit TEXT NOT NULL,
                DateTime TEXT NOT NULL
            )"
            );
    }

    public Substance CreateSubstanceTable(string SubstanceName, double DoseAmount, string Unit, DateTime DateTime)
    {
         
        using var connection = new SQLiteConnection(_connectionString);

        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = @"
                               INSERT INTO SubstancesData (Name, Description, Amount, Unit)
                               VALUES ($Name, $Description, $Amount, $Unit)
                               SELECT last_insert_rowid();
                                ";
        command.Parameters.AddWithValue("$SubstanceName", SubstanceName);
        command.Parameters.AddWithValue("$DoseAmount", DoseAmount);
        command.Parameters.AddWithValue("$Unit", Unit);
        command.Parameters.AddWithValue("$DateTime", DateTime);
        var id = command.ExecuteScalar();

        if (id == null)
        {
            AnsiConsole.MarkupLine("[red]Malfunction! Check and repair your code. This entry wont be saved.[/]");
        }

        command.ExecuteNonQuery();

        return new Substance((int)id, (string)SubstanceName, (double)DoseAmount, (string) Unit, (DateTime)DateTime);
    }
}