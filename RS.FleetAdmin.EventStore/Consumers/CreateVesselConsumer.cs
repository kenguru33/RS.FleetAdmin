using Marten;
using MassTransit;
using RS.FleetAdmin.Shared.Messages;
using RS.FleetAdmin.Shared.Messages.Vessel;

namespace RS.FleetAdmin.EventStore.Consumers;

public class CreateVesselConsumer(IDocumentStore store, IPublishEndpoint publishEndpoint) : IConsumer<CreateVessel>
{
    
    public async Task Consume(ConsumeContext<CreateVessel> context)
    {
        await using var session = store.LightweightSession();
        var vesselCreated = new VesselCreated()
        {
            VesselId = Guid.NewGuid(),
            VesselName = context.Message.VesselName
        };

        var stream = await session.Events.FetchStreamStateAsync(vesselCreated.VesselId);

        if (stream is not null)
        {
            session.Events.StartStream(vesselCreated.VesselId, vesselCreated);
        }

        await session.SaveChangesAsync();

    }
}