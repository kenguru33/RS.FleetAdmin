using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RS.FleetAdmin.VesselAPI.API.DTOs;
using RS.FleetAdmin.VesselAPI.Core.Commands;

namespace RS.FleetAdmin.VesselAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VesselController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public VesselController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }


    [HttpPost]
    public async Task<IActionResult> CreateVessel([FromBody] CreateVesselDto dto)
    {
        var result = await _mediator.Send(_mapper.Map<CreateVesselCommand>(dto));
        return Ok(result);
    }
}


