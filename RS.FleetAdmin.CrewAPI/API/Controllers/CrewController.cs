using MassTransit;
using Microsoft.AspNetCore.Mvc;
using RS.FleetAdmin.CrewAPI.API.DTOs;
using RS.FleetAdmin.CrewAPI.Application.Commands;
using RS.FleetAdmin.CrewAPI.Application.Responses;

namespace RS.FleetAdmin.CrewAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CrewController(IRequestClient<CreateCrewCommand> createCrewRequestClient) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateCrewAsync(CreateCrewDto dto)
    {
        var command = new CreateCrewCommand()
        {
            CrewName = dto.CrewName
        };
        var response = await createCrewRequestClient.GetResponse<CrewResponse>(command);
        
        return Ok(new { StatusCode = StatusCode(201), Message = "Crew created successfully"});
    }
}