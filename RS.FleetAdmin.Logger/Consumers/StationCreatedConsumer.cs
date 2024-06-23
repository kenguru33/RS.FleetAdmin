using MassTransit;
using RS.FleetAdmin.Shared.Messaging.Messages;

namespace RS.FleetAdmin.Logger.Consumers;

public class StationCreatedConsumer(ILogger<StationCreatedConsumer> logger) : IConsumer<StationCreated>
{
    public async Task Consume(ConsumeContext<StationCreated> context)
    {
        logger.LogInformation("Received message: {@Message}", context.Message);
    }
}