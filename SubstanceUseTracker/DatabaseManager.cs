using System.Data.SQLite;
using Dapper;
using System.Data;

public class DatabaseManager
{
    private string _connectionString;

    public DatabaseManager(string connectionString)
    {

        using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
        {
            _connectionString = connectionString;
            SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
        }

        using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
        {
            connection.Execute("CREATE TABLE IF NOT EXISTS Substance_Data (Id INTEGER PRIMARY KEY AUTOINCREMENT, Substance TEXT, Dosage REAL, Unit TEXT, DateTime TEXT");
        }
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