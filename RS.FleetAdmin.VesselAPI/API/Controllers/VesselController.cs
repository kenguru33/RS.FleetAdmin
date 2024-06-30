using AutoMapper;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RS.FleetAdmin.Shared.Messages;
using RS.FleetAdmin.VesselAPI.Core.Application.Commands;
using RS.FleetAdmin.VesselAPI.Core.Application.Queries;

namespace RS.FleetAdmin.VesselAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VesselController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IBus _bus;

    public VesselController(IMediator mediator, IMapper mapper, IBus bus)
    {
        _mediator = mediator;
        _mapper = mapper;
        _bus = bus;
    }


    [HttpPost]
    public async Task<IActionResult> CreateVessel([FromBody] CreateVesselCommand command)
    {
        var createVessel = new CreateVessel()
        {
            VesselName = command.VesselName
        };
        
        var sendToUri = new Uri("rabbitmq://localhost/event-source-service-create-vessel");
        var endpoint = await _bus.GetSendEndpoint(sendToUri);
        await endpoint.Send(createVessel);
        return Ok();
        
        var result = await _mediator.Send(command);
        var actionResult = CreatedAtAction(nameof(GetVesselById), new { vesselId = result.VesselId }, result);
        return actionResult;
    }
    
    [HttpGet("{vesselId}")]
    public async Task<IActionResult> GetVesselById(Guid vesselId)
    {
        var query = new GetVesselByIdQuery{ VesselId = vesselId };
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}


