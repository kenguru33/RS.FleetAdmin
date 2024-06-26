using MassTransit;
using RS.FleetAdmin.Shared.Messaging.Messages;

namespace RS.FleetAdmin.StationAPI.Messaging.Consumers;

public class CrewCreatedConsumer : IConsumer<CrewCreated>
{
    public async Task Consume(ConsumeContext<CrewCreated> context)
    {
        Console.WriteLine("Crew created");
        await Task.CompletedTask;
    }
}