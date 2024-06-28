using MassTransit;
using RS.FleetAdmin.Shared.Messages;
using RS.FleetAdmin.VesselAPI.Core.Application.Services;

namespace RS.FleetAdmin.VesselAPI.Infrastructure.Messaging.Consumers;

public class VesselCreatedConsumer : IConsumer<VesselCreated>
{
    private readonly IVesselService _vesselService;

    public VesselCreatedConsumer(IVesselService vesselService)
    {
        _vesselService = vesselService;
    }
    public Task Consume(ConsumeContext<VesselCreated> context)
    {
        // It should be created here - event sourcing
        Console.WriteLine("Create vessel here");
        return Task.CompletedTask;
    }
}