using Microsoft.IdentityModel.Abstractions;

namespace RS.FleetAdmin.Logger.Entities;

public class LogEntry 
{
    public Guid Id { get; set; }
    public DateTime Timestamp { get; set; }
    public string LogLevel { get; set; }
    public string Message { get; set; }
    public string Source { get; set; }
    public string UserId { get; set; }
    public int? ErrorCode { get; set; }
}

