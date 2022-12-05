using DS_CSCI3110_Final.Models.Entities;

namespace DS_CSCI3110_Final.Services;

/// <summary>
/// Interface for Airplane repository.
/// </summary>
public interface IAirplaneRepository
{
    Task<Airplane> CreateAsync(Airplane airplane);
    Task<Airplane?> ReadAsync(int id);
    Task<ICollection<Airplane>> ReadAllAsync();
    Task UpdateAsync(int airplaneId, Airplane airplane);
    Task DeleteAsync(int airplaneId);

    Task<Pilot> CreatePilotAsync(int airplaneId, Pilot pilot);
    Task<ICollection<Pilot>> ReadAllPilotAsync();
    Task UpdatePilotAsync(int pilotId, Pilot pilot);
}
