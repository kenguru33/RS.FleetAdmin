using System.ComponentModel.DataAnnotations;

namespace RS.FleetAdmin.CrewAPI.Domain.Entities;

public class Crew
{
    [Key]
    public Guid CrewId { get; set; }
    public string CrewName { get; set; }
}