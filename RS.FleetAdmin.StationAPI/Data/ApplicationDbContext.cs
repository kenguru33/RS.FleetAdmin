using MassTransit;
using Microsoft.EntityFrameworkCore;
using RS.FleetAdmin.Shared.Messaging;
using RS.FleetAdmin.StationAPI.Entities;

namespace RS.FleetAdmin.StationAPI.DATA;

public class ApplicationDbContext : OutboxDbContext
{
    public ApplicationDbContext(DbContextOptions<OutboxDbContext> options) : base(options)
    {
    }
    
    public DbSet<Station> Stations { get; set; }
    
}