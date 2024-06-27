using MassTransit;

namespace RS.FleetAdmin.Shared.Infrastructure;

public class MasstransitPublisher<T>(IPublishEndpoint publishEndpoint)
{
    public async Task Publish(T message)
    {
        await publishEndpoint.Publish(message);
    }
}