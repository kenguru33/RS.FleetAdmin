using MassTransit;

namespace RS.FleetAdmin.VesselAPI.Infrastructure.Messaging.Services;

public class MasstransitMessageSender(ISendEndpoint sendEndpoint) : IMessageSender
{
    public async Task Send<T>(T message, CancellationToken cancellationToken) where T : class
    {
        await sendEndpoint.Send(message, cancellationToken);
    }
}