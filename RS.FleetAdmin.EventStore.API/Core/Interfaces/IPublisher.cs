namespace RS.FleetAdmin.EventStore.API.Core.Interfaces;

public interface IPublisher
{
    public Task PublishAsync<T>(T @event, CancellationToken cancellationToken) where T : class;
}