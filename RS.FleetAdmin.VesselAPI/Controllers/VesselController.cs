using MassTransit;
using MassTransit.Mediator;
using Microsoft.AspNetCore.Mvc;
using RS.FleetAdmin.VesselAPI.Commands;

namespace RS.FleetAdmin.VesselAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VesselController : ControllerBase
{
    private readonly IRequestClient<CreateVesselCommand> _client;

    public VesselController(IRequestClient<CreateVesselCommand> client)
    {
        _client = client;
    }
    
    
    [HttpPost]
    public async Task<IActionResult> CreateVessel([FromBody] CreateVesselCommand command)
    {
        // var client = _mediator.CreateRequestClient<CreateVesselCommand>();
        var response = await _client.GetResponse<VesselResponse>(command);
        return Ok(response.Message);
    }
}