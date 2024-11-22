using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder().
    AddJsonFile("appsettings.json").
    SetBasePath(Directory.GetCurrentDirectory()).
    Build();

string connectionString = @"Data Source = substanceLogs.Data.db";

DatabaseManager databaseManager = new DatabaseManager(connectionString);
SubstanceUseApp substanceUseApp = new SubstanceUseApp(databaseManager);
try
{
    substanceUseApp.appStart();

}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
