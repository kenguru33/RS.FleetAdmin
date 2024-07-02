using AutoMapper;
using RS.FleetAdmin.Shared.Messages;
using RS.FleetAdmin.VesselAPI.Core.Application.Commands;
using RS.FleetAdmin.VesselAPI.Core.Application.Queries;
using RS.FleetAdmin.VesselAPI.Core.Application.Responses;
using RS.FleetAdmin.VesselAPI.Core.Application.Services;
using RS.FleetAdmin.VesselAPI.Core.Domain.Entities;
using RS.FleetAdmin.VesselAPI.Core.Domain.Repositories;

namespace RS.FleetAdmin.VesselAPI.Infrastructure.Messaging.Services;

public class VesselService(IVesselRepository vesselRepository, IMessagePublisher publisher, IMapper mapper)
    : IVesselService
{
    public async Task<VesselResponse> CreateVessel(CreateVesselCommand command, CancellationToken cancellationToken)
    {
        var vessel = await vesselRepository.AddVesselAsync(mapper.Map<Vessel>(command));
        var message = mapper.Map<VesselCreated>(vessel);
        await publisher.Publish(message, cancellationToken);
        
        if (!await vesselRepository.SaveChangesAsync())
            throw new Exception("Failed to save changes to the database");
        return mapper.Map<VesselResponse>(vessel);
        
        
        
    }

    public async Task<VesselResponse> GetVesselById(GetVesselByIdQuery query, CancellationToken cancellationToken)
    {
        var vessel = await vesselRepository.GetVesselByIdAsync(query.VesselId);
        return mapper.Map<VesselResponse>(vessel);
    }
}