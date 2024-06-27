using Microsoft.EntityFrameworkCore;
using RS.FleetAdmin.Shared.Infrastructure;
using RS.FleetAdmin.VesselAPI.Core.Domain.Entities;

namespace RS.FleetAdmin.VesselAPI.Infrastructure.Persistence;

public class VesselDbContext(DbContextOptions<VesselDbContext> options) : MasstransitOutboxDbContext(options)
{
    public DbSet<Vessel> Vessels { get; set; }
}