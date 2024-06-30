using EventSourceService;
using EventSourceService.Consumers;
using Marten;
using Marten.Events;
using MassTransit;
using RS.FleetAdmin.Shared.Infrastructure;
using RS.FleetAdmin.Shared.Messages;
using Weasel.Core;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

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

var x = builder.Services.ConfigureMassTransit("event-source-service");
x.AddConsumer<CreateVesselConsumer>();

var host = builder.Build();
host.Run();