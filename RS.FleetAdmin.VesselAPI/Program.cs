using MassTransit;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using RS.FleetAdmin.VesselAPI.Data;
using RS.FleetAdmin.VesselAPI.Messaging.Consumers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;
builder.Services.AddDbContext<VesselDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.AddEntityFrameworkOutbox<VesselDbContext>(outboxConfig =>
    {
        outboxConfig.QueryDelay = TimeSpan.FromSeconds(30);
        outboxConfig.UsePostgres();
        outboxConfig.UseBusOutbox();
    });
    busConfigurator.AddConsumer<StationCreatedConsumer>();
    busConfigurator.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter("station", false));
    busConfigurator.UsingRabbitMq((context, config) =>
    {
        config.Host("localhost", rabbitConfig =>
        {
            rabbitConfig.Username("rabbitmq");
            rabbitConfig.Password("rabbitmq");
        });
        config.ReceiveEndpoint("Vessel", e =>
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