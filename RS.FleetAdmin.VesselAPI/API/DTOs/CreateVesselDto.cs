using System.ComponentModel.DataAnnotations;

namespace RS.FleetAdmin.VesselAPI.API.DTOs;

public class CreateVesselDto
{
    [Required]
    public string VesselName { get; set; }
}