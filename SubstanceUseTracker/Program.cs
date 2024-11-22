// This is the main program file for the CodingTracker application. It contains the main method that is called when the application is run.
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder().
    AddJsonFile("Data Source = appsettings.json").
    SetBasePath(Directory.GetCurrentDirectory()).
    Build();



DatabaseManager _databaseManager = new DatabaseManager(connectionString);
SubstanceUseApp _substanceUseApp = new SubstanceUseApp(DatabaseManager);