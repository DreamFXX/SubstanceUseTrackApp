// Utilities that run when Program starts (get connectionString from config file etc).
namespace SubstanceUseTrackApp_Console;


private string connectionString = config.GetValue<string>("ConnectionString") ?? "";

DataService dataService = 