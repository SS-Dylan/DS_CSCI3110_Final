using DS_CSCI3110_Final.Models.Entities;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace DS_CSCI3110_Final.Services;

/// <summary>
/// Class to handle CRRUD functionalities for the Pilot entity.
/// </summary>
public class DbPilotRepository : IPilotRepository
{
    private readonly ApplicationDbContext _db;
    public DbPilotRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    /// <summary>
    /// Creates a new Pilot in the database.
    /// </summary>
    /// <param name="pilot"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Pilot> CreateAsync(Pilot pilot)
    {
        _db.Pilots.Add(pilot);
        await _db.SaveChangesAsync();
        return pilot;
    }

    /// <summary>
    /// Reads a Pilot from the database.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Pilot?> ReadAsync(int id)
    {
        return await _db.Pilots
            .Include(a => a.Airplane)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    /// <summary>
    /// Reads all Pilots from the database.
    /// </summary>
    /// <returns></returns>
    public async Task<ICollection<Pilot>> ReadAllAsync()
    {
        return await _db.Pilots
            .Include(a => a.Airplane)
            .ToListAsync();
    }

    /// <summary>
    /// Updates a Pilot in the database.
    /// </summary>
    /// <param name="pilotId"></param>
    /// <param name="pilot"></param>
    /// <returns></returns>
    public async Task UpdateAsync(int pilotId, Pilot pilot)
    {
        var aviator = await ReadAsync(pilotId);
        if (aviator != null)
        {
            aviator.FirstName = pilot.FirstName;
            aviator.LastName = pilot.LastName;  
            await _db.SaveChangesAsync();
        };
    }

    /// <summary>
    /// Deletes a Pilot from the database.
    /// </summary>
    /// <param name="pilotId"></param>
    /// <returns></returns>
    public async Task DeleteAsync(int pilotId)
    {
        var pilot = await ReadAsync(pilotId);
        if (pilot != null)
        {
            _db.Pilots.Remove(pilot);
            await _db.SaveChangesAsync();
        }
    }
}
