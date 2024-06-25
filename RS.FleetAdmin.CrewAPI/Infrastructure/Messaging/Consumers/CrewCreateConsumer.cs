using MassTransit;
using RS.FleetAdmin.CrewAPI.Application.Commands;

namespace RS.FleetAdmin.CrewAPI.Infrastructure.Messaging.Consumers;

public class CrewCreateConsumer : IConsumer<CreateCrewCommand>
{
    public async Task Consume(ConsumeContext<CreateCrewCommand> context)
    {
        Console.WriteLine("create crew consumer called");
    }
}