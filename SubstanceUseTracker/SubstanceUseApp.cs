using System.Globalization;
using Spectre.Console;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data.Common;
using System.Runtime;

class SubstanceUseApp
{
    private const string VIEW_SUBSTANCE_USE_RECORDS = "View all Substance records.";
    private const string ADD_SUBSTANCE_USAGE = "Add a record about Substance use.";
    private const string REPORT_ABOUT_RECORD = "Write a report about your mood, feelings and impacts on you.";

    private const string CHANGE_SUBSTANCE_USE_RECORDS = "Change records about Substance usage";

    private const string DELETE_RECORDS_OF_SUBSTANCE_USE = "Delete parts of already logged Substance usage.";
    private const string EXIT = "Close Application.";

    private DatabaseManager _databaseManager;
    private View _view;

    public SubstanceUseApp(DatabaseManager databaseManager)
    {
        _databaseManager = databaseManager;
        _view = new View();
        databaseManager.LoadSubstances().ForEach(substance => _view.Substance(substance));
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
    private void MenuRouter(string menuSelection) // zAČÍT ZDE!
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

    Substance CreateSubstance()
    {
        (string substanceName, double doseAmount, string unit, DateTime dateAndTime) = _view.SubstanceCreation();

        if (substanceName == "" || unit == "")
        {
            throw new Exception("You forgot to enter all required values.");
        }
        Substance substance = _databaseManager.CreateSubstance(substanceName, doseAmount, unit, dateAndTime);
        _view.Message("Substance Created!");
        return substance;
    }

    Substance GetHabit(int id)
    {
        Substance substance = _databaseManager.LoadSubstance(id) ?? throw new Exception("Tracking of entered Substance not found");
        return substance;
    }

    List<Substance> GetSubstances()
    {
        return _databaseManager.LoadSubstances();
    }


    private void AddSubstanceLog()
    {
        throw new NotImplementedException();
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