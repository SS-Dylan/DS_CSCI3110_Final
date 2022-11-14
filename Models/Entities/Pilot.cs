﻿namespace DS_CSCI3110_Final.Models.Entities;

public class Pilot
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public int AirplaneId { get; set; }
    public Airplane? Airplanes { get; set; }
}
