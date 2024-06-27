using MassTransit;
using RS.FleetAdmin.VesselAPI.Entities;

namespace RS.FleetAdmin.VesselAPI.Adapters.Messaging;

public class VesselPublisherService : IVesselPublisherService
{
    private readonly IPublishEndpoint _publishEndpoint;

    public VesselPublisherService(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }
    
    public async Task PublishVesselCreatedAsync(Vessel vessel, CancellationToken cancellationToken)
    {
        await _publishEndpoint.Publish(vessel, cancellationToken);
    }
   
}