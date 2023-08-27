using System.ComponentModel.DataAnnotations;

public class SequenceOptions
{
    public const string SectionName = "SequenceOptions";
    [Range(double.MinValue, double.MaxValue)]
    public double MaxValue { get; set; }
    [Range(double.MinValue, double.MaxValue)]
    public double MinValue { get; set; }
    public int MaxNumber { get; set; }

}