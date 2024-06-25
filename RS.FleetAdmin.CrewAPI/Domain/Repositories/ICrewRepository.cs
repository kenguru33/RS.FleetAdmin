using RS.FleetAdmin.CrewAPI.Domain.Entities;

namespace RS.FleetAdmin.CrewAPI.Domain.Repositories;

public interface ICrewRepository
{
    Task<IEnumerable<Crew>> GetCrewsAsync();
    Task<Crew> GetCrewByIdAsync(Guid crewId);
    Task<Crew> CreateCrewAsync(Crew crew);
    Task<Crew> UpdateCrewAsync(Crew crew);
    Task DeleteCrewAsync(Guid crewId);

    Task<bool> SaveChangesAsync();
}