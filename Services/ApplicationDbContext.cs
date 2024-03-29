﻿using DS_CSCI3110_Final.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DS_CSCI3110_Final.Services;

/// <summary>
/// Class to handle communications for the DB.
/// </summary>
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Airplane>? Airplanes { get; set; }
    public DbSet<Pilot>? Pilots { get; set; }
    public DbSet<DS_CSCI3110_Final.Models.ViewModels.AirplaneVM> AirplaneVM { get; set; }
    public DbSet<DS_CSCI3110_Final.Models.ViewModels.CreatePilotVM> PilotVM { get; set; }
    public DbSet<DS_CSCI3110_Final.Models.ViewModels.EditPilotVM> EditPilotVM { get; set; }
}
