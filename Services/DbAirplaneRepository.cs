using DS_CSCI3110_Final.Models.Entities;
using DS_CSCI3110_Final.Models.ViewModels;
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
    public async Task<Airplane?> ReadAsync(int id)
    {
        var airplane = await _db.Airplanes.FindAsync(id);
        if(airplane != null)
        {
            _db.Entry(airplane)
                .Collection(p => p.Pilots)
                .Load();
        }
        return airplane;
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

    /// <summary>
    /// Adds a pilot to the database
    /// </summary>
    /// <param name="pilot"></param>
    /// <returns></returns>
    public async Task<Pilot> CreatePilotAsync(int airplaneId, Pilot pilot)
    {
        await _db.Pilots.AddAsync(pilot);
        await _db.SaveChangesAsync();
        return pilot;
    }

    /// <summary>
    /// Returns all pilots in the database.
    /// </summary>
    /// <returns></returns>
    public async Task<ICollection<Pilot>> ReadAllPilotAsync()
    {
        return await _db.Pilots.ToListAsync();
    }

    /// <summary>
    /// Changes a pilots properties
    /// </summary>
    /// <param name="airplaneId"></param>
    /// <param name="updatedPilot"></param>
    /// <returns></returns>
    public async Task UpdatePilotAsync(int airplaneId, Pilot updatedPilot)
    {
        var airplane = await ReadAsync(airplaneId);
        if (airplane != null)
        {
            var pilotToUpdate = airplane.Pilots.FirstOrDefault(p => p.Id == updatedPilot.Id);
            if(pilotToUpdate != null)
            {
                pilotToUpdate.FirstName = updatedPilot.FirstName;
                pilotToUpdate.LastName = updatedPilot.LastName;
                await _db.SaveChangesAsync();
            }    
        }
    }
}
