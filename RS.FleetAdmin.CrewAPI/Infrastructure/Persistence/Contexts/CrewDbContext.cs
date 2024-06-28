using Microsoft.EntityFrameworkCore;
using RS.FleetAdmin.CrewAPI.Domain.Entities;
using RS.FleetAdmin.Shared.Infrastructure;

namespace RS.FleetAdmin.CrewAPI.Infrastructure.Persistence.Contexts;

public class CrewDbContext : MasstransitOutboxDbContext
{
    public CrewDbContext(DbContextOptions<CrewDbContext> options) : base(options)
    {
    }
    
    public DbSet<Crew> Crew { get; set; }
}