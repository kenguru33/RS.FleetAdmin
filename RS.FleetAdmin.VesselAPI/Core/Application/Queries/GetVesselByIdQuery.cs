using MediatR;
using RS.FleetAdmin.VesselAPI.Core.Application.Responses;

namespace RS.FleetAdmin.VesselAPI.Core.Application.Queries;

public class GetVesselByIdQuery : IRequest<VesselResponse>
{
    public Guid VesselId { get; set; }
}