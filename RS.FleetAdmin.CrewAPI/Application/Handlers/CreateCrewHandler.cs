using MassTransit;
using RS.FleetAdmin.CrewAPI.Application.Handlers;
using RS.FleetAdmin.CrewAPI.Application.Responses;
using RS.FleetAdmin.CrewAPI.Domain.Entities;
using RS.FleetAdmin.CrewAPI.Domain.Repositories;
using RS.FleetAdmin.Shared.Messages;

namespace RS.FleetAdmin.CrewAPI.Application.Commands.Consumers;

public class CreateCrewHandler : IConsumer<CreateCrewCommand>
{
    private readonly ICrewRepository _crewRepository;
    private readonly IPublishEndpoint _publishEndpoint;

    public CreateCrewHandler(ICrewRepository crewRepository, IPublishEndpoint publishEndpoint)
    {
        _crewRepository = crewRepository;
        _publishEndpoint = publishEndpoint;
    }
    
    
    public async Task Consume(ConsumeContext<CreateCrewCommand> context)
    {
        var command = context.Message;
        var crew = new Crew()
        {
            CrewId = Guid.NewGuid(),
            CrewName = command.CrewName
        };
        var newCrew = await _crewRepository.CreateCrewAsync(crew);
        await _publishEndpoint.Publish(new CrewCreated
        {
            CrewId = newCrew.CrewId.ToString(),
            CrewName = newCrew.CrewName
        });
        await _crewRepository.SaveChangesAsync();
        await context.RespondAsync(new CrewResponse()
        {
            CrewId = newCrew.CrewId.ToString(),
            CrewName = newCrew.CrewName
        });
    }
}