using Spectre.Console;
using System.Globalization;

class View
{
    public void Clear()
    {
        AnsiConsole.Clear();
    }

    public void Substances(List<Substance> substances)
    {
        if (substances.Count == 0)
        {
            AnsiConsole.MarkupLine("No substance use Logs were created. Start now by selecting Add records in main menu.");
            return;
        } 
    }

    private void DisplaySubstancesLogs(List<Substance> substances)
    {
        Table substanceLogsTable = new Table();
        substanceLogsTable.Title(new TableTitle("Substance Usage Trackers"));
        substanceLogsTable.AddColumns("Id", "Substance", "Dosage", "in Units", "Date and Time");
        substanceLogsTable.Columns[0].Width = 5;

        foreach (Substance substance in substances)
        {
            // Style? activeStyle = substance.IsActive ? Style.Parse("green") : null;
            Markup[] columns =
            [
                new Markup(substance.Id.ToString()),
                new Markup(substance.SubstanceName.ToString()),
                new Markup(substance.DoseAmount.ToString()),
                new Markup(substance.Unit.ToString()),
                new Markup(substance.DateTime.ToString())
            ];
            substanceLogsTable.AddRow(columns);
        }
    }

    public void Substance(Substance substance)
    {
        AnsiConsole.MarkupLine("");
        AnsiConsole.MarkupLine($"Substance: {substance.SubstanceName}");
        AnsiConsole.MarkupLine($"Dosage: {substance.DoseAmount}{substance.Unit}");
        AnsiConsole.MarkupLine($"Date and Time: {substance.DateTime}");
        AnsiConsole.MarkupLine("");
    }

}