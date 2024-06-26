using MassTransit;
using RS.FleetAdmin.Shared.Messaging.Messages;

namespace RS.FleetAdmin.CrewAPI.Infrastructure.Messaging.Consumers;

public class VesselCreatedConsumer : IConsumer<VesseLCreated>
{
    public Task Consume(ConsumeContext<VesseLCreated> context)
    {
        Console.WriteLine("Vessel created");
        return Task.CompletedTask;
    }
}