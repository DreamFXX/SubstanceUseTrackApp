using SubstanceUseTracker;

namespace SubstanceUseTracker.Models;

class SubstanceHabit
{
    public int Id { get; set; }
    public string? SubstanceName { get; set; }

    public decimal LastDoseAmount { get; set; }
    public string? Unit { get; set; }

    public TimeOnly TimeOnly { get; set; }
    public DateOnly DateOnly { get; set; }

    public decimal averageValue { get; set; }
}