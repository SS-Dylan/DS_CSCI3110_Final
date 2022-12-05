using System.ComponentModel;

namespace DS_CSCI3110_Final.Models.Entities;

public class Pilot
{
    public int Id { get; set; }
    [DisplayName("First Name")]
    public string FirstName { get; set; }
    [DisplayName("Last Name")]
    public string LastName { get; set; }

    public int AirplaneId { get; set; }
    public Airplane? Airplane { get; set; }
}
