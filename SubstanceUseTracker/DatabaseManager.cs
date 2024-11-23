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
            connection.Open();
            connection.Execute(@"CREATE TABLE IF NOT EXISTS substance_usage_datatables (
                               Id INTEGER PRIMARY KEY AUTOINCREMENT,
                               Substance TEXT NOT NULL,
                               DoseAmount REAL NOT NULL,
                               Unit TEXT NOT NULL,
                               DateTime TEXT NOT NULL
                               )");

            // Secondary table implementation for Usage Stats/Average consumptions ETC.
            // connection.Execute(@"CREATE TABLE IF NOT EXISTS secondaryUsageData ()");
            // OR just this table?
        }
    }
    //2nd mthd
    void initSubstanceTable(SQLiteConnection connection)
    {
        _connectionString = connectionString;

        using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
            connection.Execute(@"CREATE TABLE IF NOT EXISTS substance_usage_datatables (
                               Id INTEGER PRIMARY KEY AUTOINCREMENT,
                               Substance TEXT NOT NULL,
                               DoseAmount REAL NOT NULL,
                               Unit TEXT NOT NULL,
                               DateTime TEXT NOT NULL
                               )");
        }

    public Substance AddSubstanceLog(Substance specHabit)
    {
        using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();

                   string sql = (@"INSERT INTO substance_usage_data (
                                 SubstanceName, DoseAmount, Unit, DateTime) 
                        VALUES (@SubstanceName, @DoseAmount, @Unit, @DateTime)
                                ");

            connection.Execute(sql, specHabit);
        }
    }

}

