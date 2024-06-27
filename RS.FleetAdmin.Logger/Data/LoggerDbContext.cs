using Microsoft.EntityFrameworkCore;
using RS.FleetAdmin.Logger.Entities;
using RS.FleetAdmin.Shared.Infrastructure;
using RS.FleetAdmin.Shared.Messaging;

namespace RS.FleetAdmin.Logger.Data;

public class LoggerDbContext(DbContextOptions options) : MasstransitOutboxDbContext(options)
{
    public DbSet<LogEntry> LogItems { get; set; }
    
}