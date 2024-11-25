using System.Data.SQLite;
using Dapper;
using System.Data;

public class DatabaseManager
{
    private string _connectionString;

    public DatabaseManager(string connectionString)
    {
        _connectionString = connectionString;
        using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
        {
            SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
        }
    }

    void InitSubstanceTable(SQLiteConnection connection)
    {
        connection.Execute(
            @"CREATE TABLE IF NOT EXISTS Substances_Data (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                SubstanceType TEXT NOT NULL,
                Dosage REAL NOT NULL,
                Unit TEXT NOT NULL,
                DateTime TEXT NOT NULL
            )"
            );
    }

    public SubstanceType CreateSubstance(string Substance, double Dosage, string Unit, string DateTime)
    {
        using SQLiteConnection connection = new SQLiteConnection(_connectionString);

        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = @"
                               INSERT INTO Substances_Data (SubstanceType, Dosage, Unit, DateTime)
                               VALUES (@SubstanceType, @Dosage, @Unit, @DateTime)
                               ";
        command.Parameters.AddWithValue("$SubstanceType", Substance);
        command.Parameters.AddWithValue("$Dosage", Dosage);
        command.Parameters.AddWithValue("$Unit", Unit);
        command.Parameters.AddWithValue("$DateTime", DateTime);
        var id = command.ExecuteScalar();

        if (id == null)
        {
            throw new Exception("Malfunction, check your program code and fix database system. This log won´t be saved.");
        }

        command.ExecuteNonQuery();

        return new SubstanceType((int)id, (string)Substance, (double)Dosage, (string)Unit, (string)DateTime);
    }

    public SubstanceType? LoadSubstance(int id)
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

        return new SubstanceType
                            (
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetDouble(2),
                            reader.GetString(3),
                            reader.GetString(4)
                            );
    }

    public List<SubstanceType> LoadSubstances()
    {
        using var connection = new SQLiteConnection(_connectionString);
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText =
            @"SELECT * FROM Substances_Data
             ";

        using var reader = command.ExecuteReader();

        var substances = new List<SubstanceType>();
        while (reader.Read())
        {
            substances.Add(new SubstanceType
            (
            reader.GetInt32(0),
            reader.GetString(1),
            reader.GetDouble(2),
            reader.GetString(3),
            reader.GetString(4)
            ));
        }
        return substances;
    }

    class DateTimeOffsetHandler : SqlMapper.TypeHandler<DateTimeOffset>
    {
        public override DateTimeOffset Parse(object value)
        {
            Console.WriteLine(value);
            return DateTimeOffset.Parse((string)value);
        }

        public override void SetValue(IDbDataParameter parameter, DateTimeOffset value)
        {
            parameter.Value = value.LocalDateTime;
        }
    }


}