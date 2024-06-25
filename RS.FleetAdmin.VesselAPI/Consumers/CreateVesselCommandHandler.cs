using MassTransit;
using RS.FleetAdmin.VesselAPI.Commands;
using RS.FleetAdmin.VesselAPI.Entities;

namespace RS.FleetAdmin.VesselAPI.Consumers;

public class CreateVesselCommandHandler : IConsumer<CreateVesselCommand>
{
    public async Task Consume(ConsumeContext<CreateVesselCommand> context)
    {
        var response = new VesselResponse()
        {
            VesselId = Guid.NewGuid().ToString(),
            Name = context.Message.Name,
        };
        
        await context.RespondAsync(response);
        Console.WriteLine("Vessel created");
    }
}