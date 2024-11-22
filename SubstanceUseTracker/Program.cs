using Microsoft.Extensions.Configuration;

IConfigurationRoot configurationBuilder = new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .Build();

string connectionString = configurationBuilder.GetValue<string>("connectionString") ?? "";

if (string.IsNullOrEmpty(connectionString))
{
    Console.WriteLine("Configured connection String is missing from Enviromental Variables, or from Properties/launchSettings.json.\n" +
                      "Please, check your Connection String configuration  and try again.");
    return;
}

DatabaseManager databaseManager = new DatabaseManager(connectionString);
SubstanceUseApp substanceUseApp = new SubstanceUseApp(databaseManager);
try
{
    SubstanceUseApp.AppStart();

}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

Console.ReadKey();
