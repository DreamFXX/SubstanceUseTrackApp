using Spectre.Console;

class SubstanceUseApp
{
    private const string VIEW_SUBSTANCE_USE_LOGS = "View all SubstanceType records.";
    private const string CREATE_SUBSTANCE_LOG = "Add a record about SubstanceType use.";
    //private const string REPORT_ABOUT_RECORD = "Write a report about your mood, feelings and impacts on you.";

    //private const string CHANGE_SUBSTANCE_USE_LOGS = "Change records about Substance usage";

    //private const string DELETE_RECORDS_OF_SUBSTANCE_USE = "Delete parts of already logged Substance usage.";
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
            VIEW_SUBSTANCE_USE_LOGS,
            CREATE_SUBSTANCE_LOG,
            //CHANGE_SUBSTANCE_USE_LOGS,
            //REPORT_ABOUT_RECORD,

            //DELETE_RECORDS_OF_SUBSTANCE_USE,
            EXIT,
        };

        var menuSelection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title<string>("[underline]Welcome in [yellow]SubstanceType Usage Tracker![/][/]\n -[grey]Log your consumption of mind-altering Substances![/]\n\n [underline yellow]--MAIN MENU--[/]")
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
    private void MenuRouter(string menuSelection) // zAČÍT ZDE!
    {
        switch (menuSelection)
        {
            case VIEW_SUBSTANCE_USE_LOGS:
                ViewUsageLogs();
                break;
            case CREATE_SUBSTANCE_LOG:
                CreateSubstanceLog();
                break;
            //case REPORT_ABOUT_RECORD:
            //    CreateReportOfRecord();
            //    break;
            //case CHANGE_SUBSTANCE_USE_RECORDS:
            //    ChangeSubstanceUseRecord();
            //    break;
            //case DELETE_RECORDS_OF_SUBSTANCE_USE:
            //    DeleteSubstanceUseRecords();
            //    break;
            case EXIT:
                AnsiConsole.MarkupLine("Stay safe!");
                Environment.Exit(0);
                break;
        }
    }

    private void CreateSubstanceLog()
    {
        try
        {
            CreateSubstanceLog();
        }
        catch (Exception e)
        {

            AnsiConsole.WriteException(e);
        }
        
    }

    private void ViewUsageLogs()
    {
        List<SubstanceType> substanceLogs = _databaseManager.LoadSubstances();
        AnsiConsole.Clear();

        DisplaySubstancesLogs(substanceLogs);
        AnsiConsole.MarkupLine("[yellow]Press any key to continue.[/]");
        Console.ReadKey();
    }

    private void DisplaySubstancesLogs(List<SubstanceType> substances)
    {
        Table substanceLogsTable = new Table();
        substanceLogsTable.Title(new TableTitle("SubstanceType Usage Trackers"));
        substanceLogsTable.AddColumns("Id", "SubstanceType", "Dosage", "in Units", "Date and Time");
        substanceLogsTable.Columns[0].Width = 5;

        foreach (SubstanceType substance in substances)
        {
            // Style? activeStyle = substance.IsActive ? Style.Parse("green") : null;
            Markup[] columns =
            [
                new Markup(substance.Id.ToString()),
                new Markup(substance.Substance.ToString()),
                new Markup(substance.Dosage.ToString()),
                new Markup(substance.Unit.ToString()),
                new Markup(substance.DateTime.ToString())
            ];
            substanceLogsTable.AddRow(columns);
        }
        AnsiConsole.Write(substanceLogsTable);
    }

}