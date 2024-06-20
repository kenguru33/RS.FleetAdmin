using MassTransit;

namespace RS.FleetAdmin.Shared.Messaging;

public class MasstransitPublisher<T>
{
    private readonly IPublishEndpoint _publishEndpoint;

    public MasstransitPublisher(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public async Task Publish(T message)
    {
        await _publishEndpoint.Publish(message);
    }
}