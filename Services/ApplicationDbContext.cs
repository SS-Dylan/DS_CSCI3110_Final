using DS_CSCI3110_Final.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DS_CSCI3110_Final.Services;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Airplane>? Airplanes { get; set; }
    public DbSet<Pilot>? Pilots { get; set; }
}
