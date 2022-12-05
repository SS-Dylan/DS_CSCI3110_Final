using DS_CSCI3110_Final.Models.Entities;
using System.ComponentModel;

namespace DS_CSCI3110_Final.Models.ViewModels;

public class AirplaneVM
{
    public Airplane? Airplane { get; set; }
    public int Id { get; set; }
    [DisplayName("Tail Number")]
    public string TailNum { get; set; }
    public string Model { get; set; }
    public double Hours { get; set; }

    public ICollection<Pilot> Pilots = new List<Pilot>();
    
    public Airplane GetPlaneInstance()
    {
        return new Airplane
        {
            Id = Id,
            TailNum = TailNum,
            Model = Model,
            Hours = Hours
        };
    }
}
