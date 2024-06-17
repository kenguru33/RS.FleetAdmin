namespace RS.FleetAdmin.Shared.Messaging.Station;

public interface IStationCreated
{
    public string StationId { get; set; }
    public string Name { get; set; }
}