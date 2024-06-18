using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS.FleetAdmin.Shared;
using RS.FleetAdmin.Shared.Messaging.Messages;
using RS.FleetAdmin.StationAPI.DATA;
using RS.FleetAdmin.StationAPI.Entities;

namespace RS.FleetAdmin.StationAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StationController(ApplicationDbContext dbContext, IPublishEndpoint publishEndpoint) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<List<StationsResponseDto>>> All()
    {
        var stations = await dbContext.Stations.ToListAsync();
        return Ok(stations);
    }
    
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateStationDto dto)
    {
        var station = dbContext.Add(new Station()
        {
            Id = Guid.NewGuid(),
            Name = dto.Name
        });
        await publishEndpoint.Publish<StationCreated>(new { StationId = station.Entity.Id.ToString(), Name = station.Entity.Name  });
        await dbContext.SaveChangesAsync();

        return Ok();
    }
}