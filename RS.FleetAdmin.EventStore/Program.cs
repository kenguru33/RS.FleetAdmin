using Marten;
using RS.FleetAdmin.EventStore;
using RS.FleetAdmin.EventStore.Consumers;
using RS.FleetAdmin.Shared.Infrastructure;
using RS.FleetAdmin.Shared.Messages;
using Weasel.Core;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("Marten")!);
    options.UseSystemTextJsonForSerialization();
    if (builder.Environment.IsDevelopment())
    {
        options.AutoCreateSchemaObjects = AutoCreate.All;
    }

    options.Events.AddEventType<VesselCreated>();
});

var x = builder.Services.ConfigureMassTransit("event-store", builder.Configuration.GetConnectionString("rabbitMQ")!);
x.AddConsumer<CreateVesselConsumer>();

var host = builder.Build();
host.Run();