

namespace SubstanceUseTracker.Models;

class SubstanceHabit
{
    public int Id { get; set; }
    public string? SubstanceName { get; set; }

    public decimal DoseAmount { get; set; }
    public string? Unit { get; set; }

    public DateTime DateTime { get; set; }

    public decimal SumPerDay { get; set; }
    public decimal AverageConsumption { get; set; }
}