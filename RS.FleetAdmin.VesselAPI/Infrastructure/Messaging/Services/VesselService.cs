using AutoMapper;
using RS.FleetAdmin.Shared.Messaging.Messages;
using RS.FleetAdmin.VesselAPI.Core.Application.Commands;
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
        await publisher.Publish(mapper.Map<VesseLCreated>(vessel), cancellationToken);
        if (!await vesselRepository.SaveChangesAsync())
            throw new Exception("Failed to save changes to the database");
        return mapper.Map<VesselResponse>(vessel);
    }

    public async Task<VesselResponse> GetVesselById(string requestVesselId, CancellationToken cancellationToken)
    {
        var vessel = await vesselRepository.GetVesselByIdAsync(requestVesselId);
        return mapper.Map<VesselResponse>(vessel);
    }
}