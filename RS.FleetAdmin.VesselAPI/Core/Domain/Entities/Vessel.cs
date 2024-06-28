using System.ComponentModel.DataAnnotations;

namespace RS.FleetAdmin.VesselAPI.Core.Domain.Entities;

public class Vessel
{
    [Key]
    public Guid Id { get; init; }

    [Required, MaxLength(100)] public string Name { get; init; } = string.Empty;
}