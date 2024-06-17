using MassTransit;
using Microsoft.EntityFrameworkCore;
using RS.FleetAdmin.StationAPI.Entities;

namespace RS.FleetAdmin.StationAPI.DATA;

public class StationDbContext(DbContextOptions<StationDbContext> options) : DbContext(options)
{
    public DbSet<Station> Stations { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.AddOutboxStateEntity();
        modelBuilder.AddOutboxMessageEntity();
        modelBuilder.AddInboxStateEntity();
    }
}