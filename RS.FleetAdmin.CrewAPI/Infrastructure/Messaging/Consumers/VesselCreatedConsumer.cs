using MassTransit;
using RS.FleetAdmin.Shared.Messages;

namespace RS.FleetAdmin.CrewAPI.Infrastructure.Messaging.Consumers;

public class VesselCreatedConsumer : IConsumer<VesselCreated>
{
    public Task Consume(ConsumeContext<VesselCreated> context)
    {
        Console.WriteLine("Vessel created");
        return Task.CompletedTask;
    }
}