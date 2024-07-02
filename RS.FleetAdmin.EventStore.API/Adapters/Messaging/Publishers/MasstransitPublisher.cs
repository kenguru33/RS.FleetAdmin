using MassTransit;
using RS.FleetAdmin.EventStore.API.Core.Interfaces;

namespace RS.FleetAdmin.EventStore.API.Adapters.Messaging.Publishers;

public class MasstransitPublisher : IPublisher
{
    private readonly IPublishEndpoint _publishEndpoint;

    public MasstransitPublisher(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }
    public async Task PublishAsync<T>(T @event, CancellationToken cancellationToken) where T : class
    {
        await _publishEndpoint.Publish(@event, cancellationToken);
    }
}