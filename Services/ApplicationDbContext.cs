using Microsoft.EntityFrameworkCore;

namespace DS_CSCI3110_Final.Services;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    
}
