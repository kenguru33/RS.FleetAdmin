using MassTransit;
using RS.FleetAdmin.Logger.Messaging.Messages;

namespace RS.FleetAdmin.Logger.Messaging.Consumers;

public class LogEntryCreatedConsumer : IConsumer<LogEntryCreated>
{
    public Task Consume(ConsumeContext<LogEntryCreated> context)
    {
        Console.WriteLine($"Logentry created: {context.Message}");
        return Task.CompletedTask;
    }
}