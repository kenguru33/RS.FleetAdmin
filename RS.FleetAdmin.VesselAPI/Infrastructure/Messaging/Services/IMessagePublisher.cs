namespace RS.FleetAdmin.VesselAPI.Infrastructure.Messaging.Services;

public interface IMessagePublisher
{
    public Task Publish<T>(T message, CancellationToken cancellationToken) where T : class;
}