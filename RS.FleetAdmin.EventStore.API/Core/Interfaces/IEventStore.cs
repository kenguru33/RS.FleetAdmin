namespace RS.FleetAdmin.EventStore.API.Core.Interfaces;

public interface IEventStore
{
    public Task AppendEventAsync<T>(Guid aggregateId, T @event, CancellationToken cancellationToken) where T : class;
    public Task<IEnumerable<T>> GetEventsAsync<T>(Guid aggregateId, CancellationToken cancellationToken) where T : class;
}