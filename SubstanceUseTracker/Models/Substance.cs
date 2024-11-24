public class Substance
{
    public Substance(int Id, string SubstanceName, double DoseAmount, string Unit, string DateTime)
    {
        this.Id = @Id;
        this.SubstanceName = @SubstanceName;
        this.DoseAmount = @DoseAmount;
        this.Unit = @Unit;
        this.DateTime = @DateTime;
    }

    public int Id { get; } // Get primary Key from Main table
    public string SubstanceName { get; set; }

    public double DoseAmount { get; set; }
    public string Unit { get; set; }

    public string DateTime { get; set; }
}