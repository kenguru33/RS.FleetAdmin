using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using RS.FleetAdmin.Shared.Infrastructure;
using RS.FleetAdmin.Shared.Tools;
using RS.FleetAdmin.VesselAPI.Core.Application.Services;
using RS.FleetAdmin.VesselAPI.Core.Domain.Repositories;
using RS.FleetAdmin.VesselAPI.Infrastructure.Messaging.Services;
using RS.FleetAdmin.VesselAPI.Infrastructure.Persistence;
using RS.FleetAdmin.VesselAPI.Infrastructure.Persistence.Repositories;

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

// Register MappingProfile
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Register VesselRepository
builder.Services.AddScoped<IVesselRepository, VesselRepository>();

// Register VesselService
builder.Services.AddScoped<IVesselService, VesselService>();

// Register MessagePublisher
builder.Services.AddScoped<IMessagePublisher, MasstransitMessagePublisher>();

// Register MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

// Register MassTransit
var x = builder.Services.ConfigureMassTransit<VesselDbContext>("vessel-api");

// Register MassTransit consumers
x.AddConsumer<StationCreatedConsuumer>();

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

// Apply pending migrations
DbHelpers.ApplyPendingMigrations<VesselDbContext>(app.Services);

app.Run();