using JasperFx.Core;
using RS.FleetAdmin.EventStore.API.Core.Interfaces;
using RS.FleetAdmin.Shared.Messages;

namespace RS.FleetAdmin.EventStore.API.Core.Handlers.Commands;

public class CreateVesselCommandHandler : ICommandHandler
{
    private readonly IPublisher _publisher;
    private readonly IEventStore _eventStore;

    public CreateVesselCommandHandler(IPublisher publisher, IEventStore eventStore)
    {
        _publisher = publisher;
        _eventStore = eventStore;
    }
    
    public async Task Handle(CreateVessel command, CancellationToken cancellationToken)
    {
        var vesselCreatedEvent = new VesselCreated()
        {
            VesselId = Guid.NewGuid(),
            VesselName = command.VesselName
        };
        
        await _eventStore.AppendEventAsync(Guid.Parse("f2d411d1-b3cd-47d4-94eb-038da924d56d"), vesselCreatedEvent, cancellationToken);
        await _publisher.PublishAsync(vesselCreatedEvent, cancellationToken);
    }
}