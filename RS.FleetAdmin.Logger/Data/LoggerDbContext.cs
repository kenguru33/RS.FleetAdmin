using Microsoft.EntityFrameworkCore;
using RS.FleetAdmin.Logger.Entities;
using RS.FleetAdmin.Shared.Messaging;

namespace RS.FleetAdmin.Logger.Data;

public class LoggerDbContext(DbContextOptions options) : OutboxDbContext(options)
{
    public DbSet<LogEntry> LogItems { get; set; }
    
}