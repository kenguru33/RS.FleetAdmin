namespace RS.FleetAdmin.VesselAPI.Core.Application.Responses;

public class VesselResponse
{
    public Guid VesselId { get; init; }
    public string VesselName { get; init; } = string.Empty;
}