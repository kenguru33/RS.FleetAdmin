using Marten;
using MassTransit;
using RS.FleetAdmin.Shared.Messages;

namespace EventSourceService.Consumers;

public class CreateVesselConsumer(IDocumentStore store, IPublishEndpoint publishEndpoint) : IConsumer<CreateVessel>
{

    public async Task Consume(ConsumeContext<CreateVessel> context)
    {
        await Console.Out.WriteLineAsync($"Create Vessel Command: {context.Message.VesselName}");
        
        
        // Open a session for querying, loading, and updating documents
        await using var session = store.LightweightSession();
        // Insert a new vesselCreated document
        var vesselCreated = new VesselCreated
        {
            VesselName = context.Message.VesselName,
            VesselId = Guid.NewGuid()
        };
        
        // check if stream exists
        var stream = await session.Events.FetchStreamStateAsync(vesselCreated.VesselId);
        
        if (stream is null)
        {
            session.Events.StartStream(vesselCreated.VesselId, vesselCreated);
        }
        session.Events.Append(vesselCreated.VesselId, vesselCreated);
        await session.SaveChangesAsync();
        
        await publishEndpoint.Publish(vesselCreated);
    }
}