namespace DS_CSCI3110_Final.Models.Entities;

public class Airplane
{
    public int Id { get; set; }
    public string TailNum { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public double Hours { get; set; } = 0;

    public ICollection<Pilot>? Pilots { get; set; }
}
