using MassTransit;
using Microsoft.EntityFrameworkCore;
using RS.FleetAdmin.Shared.Messaging;
using RS.FleetAdmin.VesselAPI.Entities;

namespace RS.FleetAdmin.VesselAPI.Data;

public class VesselDbContext(DbContextOptions<VesselDbContext> options) : OutboxDbContext(options)
{
    public DbSet<Vessel> Vessels { get; set; }
}