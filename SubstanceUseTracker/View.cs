using Spectre.Console;
using System.Xml.Linq;

class View
{
    public void Clear()
    {
        AnsiConsole.Clear();
    }

    public void Substance(Substance substance)
    {
        Console.WriteLine();
        Console.WriteLine($"Name: {substance.SubstanceName}");
        Console.WriteLine($"Current count: {substance.DoseAmount}{substance.Unit}");
        Console.WriteLine($"Date and Time: {substance.DateTime}");
        Console.WriteLine();
    }

    public (string, double, string, string) SubstanceCreation()
    {
        string substanceName;
        double doseAmount;
        string unit;
        string dateAndTime;

        string input;
        while (true)
        {
            input = AnsiConsole.Ask<string>("Enter name of Substance you want to track.");
            if (checkInput(input, "string"))
            {
                substanceName = input;
                break;
            }
            Error("Name of the substance cant be nothing.. Try again");
        }

        while (true)
        {
            input = AnsiConsole.Ask<string>("[yellow]Enter your last consumed Dosage:[/]");
            if (checkInput(input, "double"))
            {
                double.TryParse(input, out doseAmount);
                break;
            }
            Error("Dosage entry cant be nothing, try again.");
        }
        
        while (true)
        {
            input = AnsiConsole.Ask<string>("Enter substance unit, which will be used to track your consumption: ");
            if (checkInput(input, "string"))
            {
                unit = input;
                break;
            }
            Error("Unit cannot be empty");
        }

        while (true)
        {
            input = AnsiConsole.Ask<string>("Enter the date of consumption: ");
            if (checkInput(input, "string"))
            {
                dateAndTime = input;
                break;
            }
            Error("You cant leave Date and Time empty. Try again.");
        }
        
        return (substanceName, doseAmount, unit, dateAndTime);
    }

    //Validation and easy-to-read methods
    public void Message(string message)
    {
        AnsiConsole.WriteLine(message);
    }

    public void Error(string error)
    {
        AnsiConsole.WriteLine($"Error: {error}");
    }

    public bool checkInput(string input, string type)
    {
        switch (type)
        {
            case "string":
                if (input == "")
                {
                    return false;
                }
                return true;
            case "int":
                return int.TryParse(input, out _);
            case "double":
                return double.TryParse(input, out _);
            default:
                return true;
        }
    }
}
