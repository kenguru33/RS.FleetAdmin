using MediatR;
using RS.FleetAdmin.VesselAPI.Core.Application.Responses;

namespace RS.FleetAdmin.VesselAPI.Core.Application.Queries;

public class GetVesselsQuery : IRequest<List<VesselResponse>>
{
    
}