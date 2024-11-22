using Microsoft.Extensions.Configuration;

IConfigurationRoot configurationBuilder = new ConfigurationBuilder().
    AddEnvironmentVariables().
    Build();

string connectionString = configurationBuilder.GetValue<string>("connectionString") ?? "";

DatabaseManager databaseManager = new DatabaseManager(connectionString);
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
