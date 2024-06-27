using MassTransit;

namespace RS.FleetAdmin.VesselAPI.Infrastructure.Messaging.Services;

public class MasstransitMessagePublisher(IPublishEndpoint publishEndpoint) : IMessagePublisher
{
    public async Task Publish<T>(T message, CancellationToken cancellationToken) where T : class
    {
        await publishEndpoint.Publish(message, cancellationToken);
    }
}