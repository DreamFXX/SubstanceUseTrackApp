using System.Globalization;
using Spectre.Console;

class SubstanceUseApp
{
    private const string VIEW_SUBSTANCE_USE_RECORDS = "View all Substance records.";
    private const string ADD_SUBSTANCE_USAGE = "Add a record about Substance use.";
    private const string REPORT_ABOUT_RECORD = "Write a report about your mood, feelings and impacts on you.";
    private const string CHANGE_SUBSTANCE_USE_RECORDS = "Change records about Substance usage";

    private const string DELETE_RECORDS_OF_SUBSTANCE_USE = "Delete parts of already logged Substance usage.";
    private const string EXIT = "Close Application.";

    // Implement into appsettings.json Config file!
    private const string connectionString = @"Data Source=SubstanceUserLogs.data.db";

    private DatabaseManager _databaseManager;
    public SubstanceUseApp(DatabaseManager databaseManager)
    {
        _databaseManager = databaseManager;
    }

    public void appStart()
    {
        while (true)
        {
            mainMenu();
        }
    }

    private void mainMenu()
    {
        AnsiConsole.Clear();

        List<string> operationsList = new List<string>
        {
            VIEW_SUBSTANCE_USE_RECORDS,
            ADD_SUBSTANCE_USAGE,
            CHANGE_SUBSTANCE_USE_RECORDS,
            REPORT_ABOUT_RECORD,

            DELETE_RECORDS_OF_SUBSTANCE_USE,
            EXIT,
        };

        var menuSelection = AnsiConsole.Prompt();
    }
}