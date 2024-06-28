using System.ComponentModel.DataAnnotations;
using MediatR;
using RS.FleetAdmin.VesselAPI.Core.Application.Responses;

namespace RS.FleetAdmin.VesselAPI.Core.Application.Commands;

public class CreateVesselCommand : IRequest<VesselResponse>
{
    [Required]
    public string VesselName { get; init; } = string.Empty;
}