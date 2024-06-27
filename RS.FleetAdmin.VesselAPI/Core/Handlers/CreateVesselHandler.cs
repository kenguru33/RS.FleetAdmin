using AutoMapper;
using MassTransit;
using MediatR;
using RS.FleetAdmin.Shared.Messaging.Messages;
using RS.FleetAdmin.VesselAPI.Core.Commands;
using RS.FleetAdmin.VesselAPI.Core.Repositories;
using RS.FleetAdmin.VesselAPI.Core.Responses;
using RS.FleetAdmin.VesselAPI.Entities;

namespace RS.FleetAdmin.VesselAPI.Core.Handlers;

public class CreateVesselHandler : IRequestHandler<CreateVesselCommand, VesselResponse>
{
    private readonly IVesselRepository _vesselRepository;
    private readonly IMapper _mapper;
    private readonly IPublishEndpoint _publishEndpoint;

    public CreateVesselHandler(IVesselRepository vesselRepository, IMapper mapper, IPublishEndpoint publishEndpoint)
    {
        _vesselRepository = vesselRepository;
        _mapper = mapper;
        _publishEndpoint = publishEndpoint;
    }


    public async Task<VesselResponse> Handle(CreateVesselCommand request, CancellationToken cancellationToken)
    {
        var vessel = await _vesselRepository.AddVesselAsync(_mapper.Map<Vessel>(request));
        await _publishEndpoint.Publish(_mapper.Map<VesseLCreated>(vessel), cancellationToken);
        if (!await _vesselRepository.SaveChangesAsync())
            throw new Exception("Failed to save changes to the database");

        return _mapper.Map<VesselResponse>(vessel);

    }
}
