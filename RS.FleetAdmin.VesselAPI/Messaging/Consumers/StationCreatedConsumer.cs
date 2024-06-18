using MassTransit;
using RS.FleetAdmin.Shared;
using RS.FleetAdmin.Shared.Messaging.Messages;

namespace RS.FleetAdmin.VesselAPI.Messaging.Consumers;

public class StationCreatedConsumer : IConsumer<StationCreated>
{
    public Task Consume(ConsumeContext<StationCreated> context)
    {
        Console.WriteLine($"STATION CREATED! Id: {context.Message.StationId}, Name: {context.Message.Name}");
        return Task.CompletedTask;
    }
}