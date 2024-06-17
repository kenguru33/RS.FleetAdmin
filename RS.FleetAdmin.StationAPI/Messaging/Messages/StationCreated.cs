using RS.FleetAdmin.Shared;
using RS.FleetAdmin.Shared.Messaging.Station;

namespace RS.FleetAdmin.StationAPI.Messaging.Messages;

public class StationCreated : IStationCreated
{
    public string StationId { get; set; }
    public string Name { get; set; }
}