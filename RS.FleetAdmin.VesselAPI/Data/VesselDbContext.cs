using MassTransit;
using Microsoft.EntityFrameworkCore;
using RS.FleetAdmin.VesselAPI.Entities;

namespace RS.FleetAdmin.VesselAPI.Data;

public class VesselDbContext(DbContextOptions<VesselDbContext> options) : DbContext(options)
{
    public DbSet<Vessel> Vessels { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.AddOutboxStateEntity();
        modelBuilder.AddOutboxMessageEntity();
        modelBuilder.AddInboxStateEntity();
    }
}