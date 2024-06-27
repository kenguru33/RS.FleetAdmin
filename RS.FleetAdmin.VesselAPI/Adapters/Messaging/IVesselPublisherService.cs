using RS.FleetAdmin.VesselAPI.Entities;

namespace RS.FleetAdmin.VesselAPI.Adapters.Messaging;

public interface IVesselPublisherService
{
    Task PublishVesselCreatedAsync(Vessel vessel, CancellationToken cancellationToken);
}