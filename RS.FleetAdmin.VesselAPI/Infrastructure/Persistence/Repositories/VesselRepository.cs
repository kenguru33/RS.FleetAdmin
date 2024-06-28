using Microsoft.EntityFrameworkCore;
using RS.FleetAdmin.VesselAPI.Core.Domain.Entities;
using RS.FleetAdmin.VesselAPI.Core.Domain.Repositories;

namespace RS.FleetAdmin.VesselAPI.Infrastructure.Persistence.Repositories;

public class VesselRepository : IVesselRepository
{
    private readonly VesselDbContext _context;

    public VesselRepository(VesselDbContext context)
    {
        _context = context;
    }
    public Task<IEnumerable<Vessel>> GetVesselsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Vessel> AddVesselAsync(Vessel vessel)
    {
        var newVessel = _context.Vessels.Add(vessel);
        return Task.FromResult(newVessel.Entity);
    }

    public Task<Vessel> UpdateVesselAsync(Vessel vessel)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteVesselAsync(string id)
    {
        throw new NotImplementedException();
    }
    
    public async Task<Vessel> GetVesselByIdAsync(string id)
    {
        var vessel = await _context.Vessels.FirstOrDefaultAsync(v => v.Id.ToString() == id);
        if (vessel is null) throw new Exception("Not found");
        return vessel;
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}