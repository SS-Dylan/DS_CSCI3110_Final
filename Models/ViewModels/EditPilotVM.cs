using DS_CSCI3110_Final.Models.Entities;
using System.ComponentModel;

namespace DS_CSCI3110_Final.Models.ViewModels;

public class EditPilotVM
{
    public Airplane? Airplane { get; set; }
    public int Id { get; set; }
    [DisplayName("First Name")]
    public string? FirstName { get; set; }
    [DisplayName("Last Name")]
    public string? LastName { get; set; }
    public Pilot GetPilotInstance()
    {
        return new Pilot
        {
            Id = this.Id,
            FirstName = this.FirstName,
            LastName = this.LastName
        };
    }
}
