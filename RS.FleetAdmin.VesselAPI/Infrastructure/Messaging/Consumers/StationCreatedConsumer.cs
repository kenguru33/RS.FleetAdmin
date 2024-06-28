using MassTransit;
using RS.FleetAdmin.Shared.Messages;

namespace RS.FleetAdmin.VesselAPI.Infrastructure.Messaging.Consumers;

public class StationCreatedConsumer : IConsumer<StationCreated>
{
    public Task Consume(ConsumeContext<StationCreated> context)
    {
        Console.WriteLine($"Received StationCreated event: {context.Message.StationId}");
        return Task.CompletedTask;
    }
}