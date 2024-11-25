public class SubstanceType
{
    public SubstanceType(int Id, string Substance, double Dosage, string Unit, string DateTime)
    {
        this.Id = @Id;
        this.Substance = @Substance;
        this.Dosage = @Dosage;
        this.Unit = @Unit;
        this.DateTime = @DateTime;
    }

    public int Id { get; } // Get primary Key from Main table
    public string Substance { get; set; }

    public double Dosage { get; set; }
    public string Unit { get; set; }

    public string DateTime { get; set; }
}