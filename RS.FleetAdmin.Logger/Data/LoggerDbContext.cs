using Microsoft.EntityFrameworkCore;
using RS.FleetAdmin.Logger.Entities;

namespace RS.FleetAdmin.Logger.Data;

public class LoggerDbContext(DbContextOptions<LoggerDbContext> options) : DbContext(options)
{
    public DbSet<LogEntry> LogItems { get; set; }
    
}