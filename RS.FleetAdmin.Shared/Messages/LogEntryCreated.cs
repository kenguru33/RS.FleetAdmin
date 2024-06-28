namespace RS.FleetAdmin.Shared.Messages;

public class LogEntryCreated
{
    public class LogEntry 
    {
        public string Id { get; set; }
        public string Message { get; set; }
    }
}