using DS_CSCI3110_Final.Models.Entities;
using System.ComponentModel;

namespace DS_CSCI3110_Final.Models.ViewModels;

public class PilotVM
{
    public int Id { get; set; }
    [DisplayName("First Name")]
    public string FirstName { get; set; } = string.Empty;
    [DisplayName("Last Name")]
    public string LastName { get; set; } = string.Empty;

    public int AirplaneID { get; set; }
    public Airplane? Airplane { get; set; }

    public Pilot GetPilotInstance()
    {
        return new Pilot
        {
            Id = Id,
            FirstName = FirstName,
            LastName = LastName,
            AirplaneId = AirplaneID,
            Airplane = Airplane
        };
    }
}
