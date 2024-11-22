using System.Globalization;
using Spectre.Console;

namespace SubstanceUseTracker;

class SubstanceUseApp
{
    private const string VIEW_SUBSTANCE_USE_RECORDS = "View all Substance records.";

    private const string ADD_SUBSTANCE_USAGE = "Add a record about Substance use.";
    private const string CHANGE_SUBSTANCE_USE_RECORDS = "Change records about Substance usage";
    private const string DELETE_RECORDS_OF_SUBSTANCE_USE = "Delete parts of already logged Substance usage.";

    private const string REPORT_ABOUT_RECORD = "Write a report about your mood, feelings and impacts on you.";
    private const string EXIT = "Close Application.";

    private const string connectionString = @"Data Source=SubstanceUserLogs.data.db";

    private DatabaseManager _databaseManager;

}