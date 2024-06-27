using MediatR;
using RS.FleetAdmin.VesselAPI.Core.Application.Responses;

namespace RS.FleetAdmin.VesselAPI.Core.Application.Commands;

public class CreateVesselCommand : IRequest<VesselResponse>
{
    public Guid VesselId { get; set; }
    public string VesselName { get; set; }
}