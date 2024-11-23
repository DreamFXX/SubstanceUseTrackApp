﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.Extensions.Configuration.Json;

IConfigurationRoot configurationBuilder = new ConfigurationBuilder()
    .AddJsonFile("Properties\\launchSettings.json")
    .AddEnvironmentVariables()
    .Build();

string connectionString = configurationBuilder.GetValue<string>("connectionString") ?? "";

DatabaseManager databaseManager = new DatabaseManager(connectionString);
SubstanceUseApp substanceUseApp = new SubstanceUseApp(databaseManager);
try
{
    substanceUseApp.AppStart();

}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

Console.ReadKey();
