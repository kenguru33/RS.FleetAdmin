using Microsoft.EntityFrameworkCore;
using RS.FleetAdmin.CrewAPI.Entities;
using RS.FleetAdmin.Shared.Messaging;

namespace RS.FleetAdmin.CrewAPI.Data;

public class CrewDbContext : OutboxDbContext
{
    public CrewDbContext(DbContextOptions<CrewDbContext> options) : base(options)
    {
    }
    
    public DbSet<Crew> Stations { get; set; }
}