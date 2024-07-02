using MassTransit;
using RS.FleetAdmin.EventStore.API.Core.Handlers.Commands;
using RS.FleetAdmin.Shared.Messages;

namespace RS.FleetAdmin.EventStore.API.Adapters.Messaging.Consumers;

public class MasstransitCreateVesselCommandConsumer : IConsumer<CreateVessel>
{
    private readonly CreateVesselCommandHandler _createVesselCommandHandler;

    public MasstransitCreateVesselCommandConsumer(CreateVesselCommandHandler createVesselCommandHandler)
    {
        _createVesselCommandHandler = createVesselCommandHandler;
    }
    public async Task Consume(ConsumeContext<CreateVessel> context)
    {
        await _createVesselCommandHandler.Handle(context.Message, context.CancellationToken);
    }
}