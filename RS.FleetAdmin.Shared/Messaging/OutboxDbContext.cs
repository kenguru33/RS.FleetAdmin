using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace RS.FleetAdmin.Shared.Messaging;

public abstract class OutboxDbContext : DbContext
{
    protected OutboxDbContext(DbContextOptions options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.AddOutboxStateEntity();
        modelBuilder.AddOutboxMessageEntity();
        modelBuilder.AddInboxStateEntity();
    }
}