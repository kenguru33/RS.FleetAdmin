using RS.FleetAdmin.VesselAPI.Core.Repositories;
using RS.FleetAdmin.VesselAPI.Entities;

namespace RS.FleetAdmin.VesselAPI.Data.Repositories;

public class VesselRepository : IVesselRepository
{
    private readonly VesselDbContext _context;

    public VesselRepository(VesselDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Vessel>> GetVesselsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Vessel> AddVesselAsync(Vessel vessel)
    {
        var newVessel = _context.Vessels.Add(vessel);
        return newVessel.Entity;
    }

    public async Task<Vessel> UpdateVesselAsync(Vessel vessel)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteVesselAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Vessel> GetVesselByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}