using DS_CSCI3110_Final.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DS_CSCI3110_Final.Services;

/// <summary>
/// Repository to handle CRRUD methods for the Airplane entity.
/// </summary>
public class DbAirplaneRepository : IAirplaneRepository
{
    private readonly ApplicationDbContext _db;
    public DbAirplaneRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    
    /// <summary>
    /// Adds new airplane to the database.
    /// </summary>
    /// <param name="airplane"></param>
    /// <returns></returns>
    public async Task<Airplane> CreateAsync(Airplane airplane)
    {
        await _db.Airplanes.AddAsync(airplane);
        await _db.SaveChangesAsync();
        return airplane;
    }
    
    /// <summary>
    /// Displays one specific airplane.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Airplane> ReadAsync(int id)
    {
        return await _db.Airplanes
            .Include(p => p.Pilots)
            .FirstOrDefaultAsync(a => a.Id == id);
    }
    
    /// <summary>
    /// Returns entire list of airplanes in the table.
    /// </summary>
    /// <returns></returns>
    public async Task<ICollection<Airplane>> ReadAllAsync()
    {
        return await _db.Airplanes
                .Include(p => p.Pilots)
                .ToListAsync();
    }
    
    /// <summary>
    /// Allows for the editing of airplane entities.
    /// </summary>
    /// <param name="airplaneId"></param>
    /// <param name="airplane"></param>
    /// <returns></returns>
    public async Task UpdateAsync(int airplaneId, Airplane airplane)
    {
        var plane = await ReadAsync(airplaneId);
        if (plane != null)
        {
            plane.TailNum = airplane.TailNum;
            plane.Model = airplane.Model;
            plane.Hours = airplane.Hours;
            await _db.SaveChangesAsync();
        };
    }
    
    /// <summary>
    /// Removes an airplane from the database.
    /// </summary>
    /// <param name="airplaneId"></param>
    /// <returns></returns>
    public async Task DeleteAsync(int airplaneId)
    {
        var airplane = await ReadAsync(airplaneId);
        if (airplane != null)
        {
            _db.Airplanes.Remove(airplane);
            await _db.SaveChangesAsync();
        }
    }
}
