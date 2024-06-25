using MassTransit;
using RS.FleetAdmin.CrewAPI.Domain.Entities;
using RS.FleetAdmin.CrewAPI.Domain.Repositories;

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
        await _crewRepository.CreateCrewAsync(crew);
        
    }
}