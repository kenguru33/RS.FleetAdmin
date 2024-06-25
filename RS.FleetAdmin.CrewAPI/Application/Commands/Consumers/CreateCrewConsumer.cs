using MassTransit;
using RS.FleetAdmin.CrewAPI.Domain.Entities;
using RS.FleetAdmin.CrewAPI.Domain.Repositories;
using RS.FleetAdmin.Shared.Messaging.Messages;

namespace RS.FleetAdmin.CrewAPI.Application.Commands.Consumers;

public class CreateCrewConsumer(ICrewRepository crewRepository) : IConsumer<CreateCrewCommand>
{
    private readonly ICrewRepository _crewRepository = crewRepository;

    public async Task Consume(ConsumeContext<CreateCrewCommand> context)
    {
        var command = context.Message;
        var crew = new Crew()
        {
            CrewId = Guid.NewGuid(),
            CrewName = command.CrewName
        };
        var newCrew = await _crewRepository.CreateCrewAsync(crew);
        await context.Publish<CrewCreated>(new CrewCreated
        {
            CrewId = newCrew.CrewId.ToString(),
            CrewName = newCrew.CrewName
        });
        await _crewRepository.SaveChangesAsync();
    }
}