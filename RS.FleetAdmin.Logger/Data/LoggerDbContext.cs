using Microsoft.EntityFrameworkCore;
using RS.FleetAdmin.Logger.Entities;
using RS.FleetAdmin.Shared.Infrastructure;

namespace RS.FleetAdmin.Logger.Data;

public class LoggerDbContext(DbContextOptions options) : MasstransitOutboxDbContext(options)
{
    public DbSet<LogEntry> LogItems { get; set; }
    
}