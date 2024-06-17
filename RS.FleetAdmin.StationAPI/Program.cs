using MassTransit;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using RS.FleetAdmin.StationAPI.DATA;
using RS.FleetAdmin.StationAPI.Messaging.Consumers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;
builder.Services.AddDbContext<StationDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.AddEntityFrameworkOutbox<StationDbContext>(outboxConfig =>
    {
        outboxConfig.QueryDelay = TimeSpan.FromSeconds(10);
        outboxConfig.UsePostgres();
        outboxConfig.UseBusOutbox();
    });
    // busConfigurator.AddConsumer<StationCreatedHandler>();
    busConfigurator.AddConsumersFromNamespaceContaining<StationCreatedConsumer>();
    busConfigurator.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter("station", false));
    busConfigurator.UsingRabbitMq((context, config) =>
    {
        config.Host("localhost", rabbitConfig =>
        {
            rabbitConfig.Username("rabbitmq");
            rabbitConfig.Password("rabbitmq");
        });
        config.ReceiveEndpoint("Station", e =>
        {
            e.ConfigureConsumer<StationCreatedConsumer>(context);
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