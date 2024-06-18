using RS.FleetAdmin.Shared;

namespace RS.FleetAdmin.StationAPI.Messaging.Messages;

public class StationCreated : Shared.Messaging.Messages.StationCreated
{
    public string StationId { get; set; }
    public string Name { get; set; }
}