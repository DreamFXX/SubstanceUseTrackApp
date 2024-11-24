using System.Data.SQLite;
using Spectre.Console;
using Dapper;

public class DatabaseManager
{
    private string _connectionString;

    public DatabaseManager(string connectionString)
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

    public Substance CreateSubstance(string SubstanceName, double DoseAmount, string Unit, DateTime DateTime)
    {
        using SQLiteConnection connection = new SQLiteConnection(_connectionString);

        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = @"
                               INSERT INTO Substances_Data (Name, Description, Amount, Unit)
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
            throw new Exception("Malfunction, check your program code and fix database system. This log won´t be saved.");
        }

        command.ExecuteNonQuery();

        return new Substance((int)id, (string)SubstanceName, (double)DoseAmount, (string)Unit, (DateTime)DateTime);
    }

    public Substance? LoadSubstance(int id)
    {
        using SQLiteConnection connection = new SQLiteConnection(_connectionString);

        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText =
        @"
            SELECT * FROM Substances_Data WHERE Id = $Id;
        ";
        command.Parameters.AddWithValue("$Id", id);

        using var reader = command.ExecuteReader();

        if (!reader.Read())
        {
            return null;
        }

        return new Substance
                            (
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetDouble(2),
                            reader.GetString(3),
                            reader.GetDateTime(4)
                            );
    }

    public List<Substance> LoadSubstances()
    {
        using var connection = new SQLiteConnection(_connectionString);
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText =
            @"SELECT * FROM Substances_Data
             ";

        using var reader = command.ExecuteReader();

        var substances = new List<Substance>();
        while (reader.Read())
        {
            substances.Add(new Substance
            (
            reader.GetInt32(0),
            reader.GetString(1),
            reader.GetDouble(2),
            reader.GetString(3),
            reader.GetDateTime(4)
            ));
        }
        return substances;
    }
    
}