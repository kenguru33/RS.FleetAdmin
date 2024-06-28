using RS.FleetAdmin.VesselAPI.Core.Domain.Entities;

namespace RS.FleetAdmin.VesselAPI.Core.Domain.Repositories;

public interface IVesselRepository
{
    public Task<IEnumerable<Vessel>> GetVesselsAsync();
    public Task<Vessel> AddVesselAsync(Vessel vessel);
    public Task<Vessel> UpdateVesselAsync(Vessel vessel);
    public Task<bool> DeleteVesselAsync(Guid id);
    public Task<Vessel> GetVesselByIdAsync(Guid id);
    public Task<bool> SaveChangesAsync();
}