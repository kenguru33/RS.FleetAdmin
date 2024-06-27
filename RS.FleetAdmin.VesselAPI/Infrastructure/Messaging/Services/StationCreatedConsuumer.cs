using MassTransit;
using RS.FleetAdmin.Shared.Messaging.Messages;

namespace RS.FleetAdmin.VesselAPI.Infrastructure.Messaging.Services;

public class StationCreatedConsuumer : IConsumer<StationCreated>
{
    public Task Consume(ConsumeContext<StationCreated> context)
    {
        Console.WriteLine($"Received StationCreated event: {context.Message.StationId}");
        return Task.CompletedTask;
    }
}