using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace RS.FleetAdmin.Shared.Messaging;

public abstract class OutboxDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.AddOutboxStateEntity();
        modelBuilder.AddOutboxMessageEntity();
        modelBuilder.AddInboxStateEntity();
    }
}