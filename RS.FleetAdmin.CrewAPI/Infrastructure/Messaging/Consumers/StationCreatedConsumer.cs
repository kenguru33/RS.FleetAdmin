using MassTransit;
using RS.FleetAdmin.Shared.Messaging.Messages;

namespace RS.FleetAdmin.CrewAPI.Infrastructure.Messaging.Consumers;

public class StationCreatedConsumer : IConsumer<StationCreated>
{
    public async Task Consume(ConsumeContext<StationCreated> context)
    {
        Console.WriteLine("Station created");
        await Task.CompletedTask;
    }
}