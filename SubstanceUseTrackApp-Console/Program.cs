// Utilities that run when Program starts (get connectionString from config file etc).

using Microsoft.Extensions.Configuration;

IConfigurationRoot config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

string conn = config.GetValue<string>("DefaultConnection");

Console.ReadKey();
