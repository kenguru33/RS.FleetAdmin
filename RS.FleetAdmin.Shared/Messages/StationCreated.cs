namespace RS.FleetAdmin.Shared.Messages;

public class StationCreated
{
    public Guid StationId { get; set; }
    public string Name { get; set; } = string.Empty;
}