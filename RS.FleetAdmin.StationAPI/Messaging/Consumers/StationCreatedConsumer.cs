using MassTransit;
using RS.FleetAdmin.Shared;
using RS.FleetAdmin.Shared.Messaging.Station;

namespace RS.FleetAdmin.StationAPI.Messaging.Consumers;

public class StationCreatedConsumer : IConsumer<IStationCreated>
{
    public Task Consume(ConsumeContext<IStationCreated> context)
    {
        Console.WriteLine($"STATION CREATED! Id: {context.Message.StationId}, Name: {context.Message.Name}");
        return Task.CompletedTask;
    }
}