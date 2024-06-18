using MassTransit;
using RS.FleetAdmin.Shared.Messaging.Logging;

namespace RS.FleetAdmin.Logger.Messaging.Messages;

public class LogEntryCreated : Shared.Messaging.Logging.LogEntryCreated, IConsumer
{
    
}