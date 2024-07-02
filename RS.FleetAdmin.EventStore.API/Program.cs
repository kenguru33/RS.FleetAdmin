using Marten;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using RS.FleetAdmin.EventStore.API.Adapters.Messaging.Consumers;
using RS.FleetAdmin.EventStore.API.Adapters.Messaging.Publishers;
using RS.FleetAdmin.EventStore.API.Adapters.Persistence.Data;
using RS.FleetAdmin.EventStore.API.Adapters.Persistence.EventStore;
using RS.FleetAdmin.EventStore.API.Core.Handlers.Commands;
using RS.FleetAdmin.EventStore.API.Core.Interfaces;
using RS.FleetAdmin.Shared.Infrastructure;
using RS.FleetAdmin.Shared.Messages;
using Weasel.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureSerilog();
// db context
var configuration = builder.Configuration;
builder.Services.AddDbContext<EventStoreDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("EventStoreDB")));

var x = builder.Services.ConfigureMassTransit<EventStoreDbContext>("event-source-service");
x.AddConsumersFromNamespaceContaining(typeof(MasstransitCreateVesselCommandConsumer));

builder.Services.AddMarten(options =>
{
    // Establish the connection string to your Marten database
    
    options.Connection(builder.Configuration.GetConnectionString("Marten")!);
    
    // Specify that we want to use STJ as our serializer
    options.UseSystemTextJsonForSerialization();

    // If we're running in development mode, let Marten just take care
    // of all necessary schema building and patching behind the scenes
    if (builder.Environment.IsDevelopment())
    {
        options.AutoCreateSchemaObjects = AutoCreate.All;
    }
    
    // Register the event store
    options.Events.AddEventType(typeof(VesselCreated));
    
});
builder.Services.AddScoped<CreateVesselCommandHandler>();
builder.Services.AddScoped<IPublisher, MasstransitPublisher>();
builder.Services.AddSingleton<IEventStore, MartenEventStore>();

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