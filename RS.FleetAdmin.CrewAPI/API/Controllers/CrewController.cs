using MassTransit;
using MassTransit.Mediator;
using Microsoft.AspNetCore.Mvc;
using RS.FleetAdmin.CrewAPI.API.DTOs;
using RS.FleetAdmin.CrewAPI.Application.Commands;
using RS.FleetAdmin.CrewAPI.Application.Handlers;
using RS.FleetAdmin.CrewAPI.Application.Responses;

namespace RS.FleetAdmin.CrewAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CrewController : ControllerBase
{
    private readonly IRequestClient<CreateCrewCommand> _createCrewRequestClient;
    private readonly IMediator _mediator;

    public CrewController(IRequestClient<CreateCrewCommand> createCrewRequestClient)
    {
        _createCrewRequestClient = createCrewRequestClient;
    }
    [HttpPost]
    public async Task<IActionResult> CreateCrewAsync(CreateCrewDto dto)
    {
        var command = new CreateCrewCommand()
        {
            CrewName = dto.CrewName
        };
        
        var response = await _createCrewRequestClient.GetResponse<CrewResponse>(command);
        return Ok(response.Message);
    }
}