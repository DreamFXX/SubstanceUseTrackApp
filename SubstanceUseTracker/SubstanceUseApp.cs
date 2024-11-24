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

    private DatabaseManager _databaseManager;
    public SubstanceUseApp(DatabaseManager databaseManager)
    {
        _databaseManager = databaseManager;
    }

    public void AppStart()
    {
        while (true)
        {
            MainMenu();
        }
    }

    private void MainMenu()
    {
        AnsiConsole.Clear();

        List<string> menuOperations = new List<string>
        {
            VIEW_SUBSTANCE_USE_RECORDS,
            ADD_SUBSTANCE_USAGE,
            CHANGE_SUBSTANCE_USE_RECORDS,
            REPORT_ABOUT_RECORD,

            DELETE_RECORDS_OF_SUBSTANCE_USE,
            EXIT,
        };

        var menuSelection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title<string>("[underline]Welcome in [yellow]Substance Usage Tracker![/][/]\n -[grey]Log your consumption of mind-altering Substances![/]\n\n [underline yellow]--MAIN MENU--[/]")
            .PageSize(10)
            .MoreChoicesText("[grey](Move up and down with arrows to reveal more options.)[/]")
            .AddChoices(menuOperations)
            );
        try
        {
            MenuRouter(menuSelection);
        }
        catch (Exception e)
        {
            AnsiConsole.MarkupLine($"[red]Error: {e.Message}[/]");
            Console.ReadKey();
        }
    }

    private void MenuRouter(string menuSelection)
    {
        switch (menuSelection)
        {
            case ADD_SUBSTANCE_USAGE:
                AddSubstanceLog();
                break;
            case VIEW_SUBSTANCE_USE_RECORDS:
                ViewSubstanceUseRecords();
                break;
            case REPORT_ABOUT_RECORD:
                CreateReportOfRecord();
                break;

            case CHANGE_SUBSTANCE_USE_RECORDS:
                ChangeSubstanceUseRecord();
                break;
            case DELETE_RECORDS_OF_SUBSTANCE_USE:
                DeleteSubstanceUseRecords();
                break;

            case EXIT:
                AnsiConsole.MarkupLine("Stay safe!");
                Environment.Exit(0);
                break;
        }
    }

    private void AddSubstanceLog()
    {

    }

    private static void ViewSubstanceUseRecords()
    {
        throw new NotImplementedException();
    }

    private static void CreateReportOfRecord()
    {
        throw new NotImplementedException();
    }

    private static void ChangeSubstanceUseRecord()
    {
        throw new NotImplementedException();
    }

    private static void DeleteSubstanceUseRecords()
    {
        throw new NotImplementedException();
    }

}