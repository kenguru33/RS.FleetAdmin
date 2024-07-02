using Microsoft.EntityFrameworkCore;
using RS.FleetAdmin.Shared.Infrastructure;

namespace RS.FleetAdmin.EventStore.API.Adapters.Persistence.Data;

public class EventStoreDbContext(DbContextOptions options) : MasstransitOutboxDbContext(options)
{
    
}