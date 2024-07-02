namespace RS.FleetAdmin.VesselAPI.Infrastructure.Messaging.Services;

public interface IMessageSender
{
    public Task Send<T>(T message, CancellationToken cancellationToken) where T : class;
}