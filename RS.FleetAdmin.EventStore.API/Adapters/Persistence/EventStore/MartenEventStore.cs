using JasperFx.Core;
using Marten;
using MassTransit.Initializers;
using RS.FleetAdmin.EventStore.API.Core.Interfaces;

namespace RS.FleetAdmin.EventStore.API.Adapters.Persistence.EventStore;

public class MartenEventStore : IEventStore
{
    private readonly IDocumentStore _store;

    public MartenEventStore(IDocumentStore store)
    {
        _store = store;
    }
    public async Task AppendEventAsync<T>(Guid aggregateId, T @event, CancellationToken cancellationToken) where T : class
    {
        await using var session = _store.LightweightSession();
        session.Events.Append(aggregateId, @event);
        await session.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<T>> GetEventsAsync<T>(Guid aggregateId, CancellationToken cancellationToken) where T : class
    {
        await using var session = _store.LightweightSession();
        var events = session.Events.FetchStream(aggregateId);
        return events.Select(x => x.Data).OfType<T>().ToArray();
    }
}