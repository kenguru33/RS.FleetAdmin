namespace RS.FleetAdmin.Shared.Messages;

public class VesselCreated
{
    public Guid VesselId { get; init; }
    public string VesselName { get; init; } = string.Empty;
}