using Microsoft.Extensions.Configuration;
using System;

var builder = new ConfigurationBuilder().
    AddJsonFile("appsettings.json").
    SetBasePath(Directory.GetCurrentDirectory()).
    Build();

string connectionString = @"Data Source = substanceLogs.Data.db";

DatabaseManager databaseManager = new DatabaseManager(connectionString);
SubstanceUseApp substanceUseApp = new SubstanceUseApp(DatabaseManager);
try
{
    substanceUseApp.appStart();

}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
