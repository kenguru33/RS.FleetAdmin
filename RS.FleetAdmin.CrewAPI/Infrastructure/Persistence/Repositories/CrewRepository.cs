using RS.FleetAdmin.CrewAPI.Domain.Entities;
using RS.FleetAdmin.CrewAPI.Domain.Repositories;
using RS.FleetAdmin.CrewAPI.Infrastructure.Persistence.Contexts;

namespace RS.FleetAdmin.CrewAPI.Infrastructure.Persistence.Repositories;

public class CrewRepository(CrewDbContext context) : ICrewRepository
{
    private readonly CrewDbContext _context = context;

    public async Task<IEnumerable<Crew>> GetCrewsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Crew> GetCrewByIdAsync(Guid crewId)
    {
        throw new NotImplementedException();
    }

    public async Task<Crew> CreateCrewAsync(Crew crew)
    {
        var newCrew = await _context.Crew.AddAsync(crew);
        return newCrew.Entity;
    }

    public async Task<Crew> UpdateCrewAsync(Crew crew)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteCrewAsync(Guid crewId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}