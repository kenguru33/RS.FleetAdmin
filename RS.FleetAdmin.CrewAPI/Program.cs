using System.Reflection;
using MassTransit;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using RS.FleetAdmin.CrewAPI.Application.Commands;
using RS.FleetAdmin.CrewAPI.Application.Commands.Consumers;
using RS.FleetAdmin.CrewAPI.Application.Handlers;
using RS.FleetAdmin.CrewAPI.Domain.Repositories;
using RS.FleetAdmin.CrewAPI.Infrastructure.Messaging.Consumers;
using RS.FleetAdmin.CrewAPI.Infrastructure.Persistence.Contexts;
using RS.FleetAdmin.CrewAPI.Infrastructure.Persistence.Repositories;
using RS.FleetAdmin.Shared.Infrastructure;
using RS.FleetAdmin.Shared.Tools;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;
builder.Services.AddDbContext<CrewDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

var x = builder.Services.ConfigureMassTransit<CrewDbContext>("crew-api");
x.AddConsumersFromNamespaceContaining(typeof(VesselCreatedConsumer));

x.AddMediator(mediator =>
{
    mediator.AddConsumersFromNamespaceContaining(typeof(CreateCrewHandler));
    mediator.AddRequestClient<CreateCrewCommand>();
});

builder.Services.AddScoped<ICrewRepository, CrewRepository>();

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
DbHelpers.ApplyPendingMigrations<CrewDbContext>(app.Services);

app.Run();