using MassTransit;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Abstractions;
using RS.FleetAdmin.Logger.Data;
using RS.FleetAdmin.Logger.Messaging.Messages;
using RS.FleetAdmin.Shared.Messaging.Logging;
using LogEntryCreated = RS.FleetAdmin.Logger.Messaging.Messages.LogEntryCreated;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;
builder.Services.AddDbContext<LoggerDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.AddEntityFrameworkOutbox<LoggerDbContext>(outboxConfig =>
    {
        outboxConfig.QueryDelay = TimeSpan.FromSeconds(30);
        outboxConfig.UsePostgres();
        outboxConfig.UseBusOutbox();
    });
    // busConfigurator.AddConsumer<StationCreatedConsumer>();
    busConfigurator.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter("logger", false));
    busConfigurator.UsingRabbitMq((context, config) =>
    {
        config.Host("localhost", rabbitConfig =>
        {
            rabbitConfig.Username("rabbitmq");
            rabbitConfig.Password("rabbitmq");
        });
        config.ReceiveEndpoint("Logger", e =>
        {
            e.ConfigureConsumer<LogEntryCreated>(context);
        });
        config.ConfigureEndpoints(context);
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();