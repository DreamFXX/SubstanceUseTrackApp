using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Security.Cryptography.X509Certificates;

var builder = new ConfigurationBuilder().
    AddJsonFile("appsettings.json").
    SetBasePath(Directory.GetCurrentDirectory()).
    Build();

//string connectionString = @"substanceUsage.data.db";
string connectionString0 = builder.GetConnectionString("DefaultConnection");

DatabaseManager databaseManager = new DatabaseManager(connectionString0);
SubstanceUseApp substanceUseApp = new SubstanceUseApp(databaseManager);

Console.ReadKey();

try
{
    substanceUseApp.appStart();

}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
