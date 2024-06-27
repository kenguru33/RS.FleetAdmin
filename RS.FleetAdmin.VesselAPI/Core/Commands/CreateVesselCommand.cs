using MediatR;
using RS.FleetAdmin.VesselAPI.Core.Responses;

namespace RS.FleetAdmin.VesselAPI.Core.Commands;

public class CreateVesselCommand : IRequest<VesselResponse>
{
    public Guid VesselId { get; set; }
    public string VesselName { get; set; }
}