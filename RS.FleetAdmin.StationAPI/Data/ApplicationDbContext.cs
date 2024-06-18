using MassTransit;
using Microsoft.EntityFrameworkCore;
using RS.FleetAdmin.Shared.Messaging;
using RS.FleetAdmin.StationAPI.Entities;

namespace RS.FleetAdmin.StationAPI.DATA;

public class ApplicationDbContext : OutboxDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    public DbSet<Station> Stations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}