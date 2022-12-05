using DS_CSCI3110_Final.Models.Entities;

namespace DS_CSCI3110_Final.Services;

/// <summary>
/// Interface for the Pilot Repository
/// </summary>
public interface IPilotRepository
{
    Task<Pilot> CreateAsync(Pilot pilot);
    Task<Pilot?> ReadAsync(int id);
    Task<ICollection<Pilot>> ReadAllAsync();
    Task UpdateAsync(int pilotId, Pilot pilot);
    Task DeleteAsync(int pilotId);
}
