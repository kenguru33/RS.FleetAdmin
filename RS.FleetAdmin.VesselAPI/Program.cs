using System.Reflection;
using MassTransit;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using RS.FleetAdmin.Shared.Messaging;
using RS.FleetAdmin.Shared.Tools;
using RS.FleetAdmin.VesselAPI.Core.Repositories;
using RS.FleetAdmin.VesselAPI.Data;
using RS.FleetAdmin.VesselAPI.Data.Repositories;

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

// Register VesselMappingProfile
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Register VesselRepository
builder.Services.AddScoped<IVesselRepository, VesselRepository>();

// Register MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var x = builder.Services.ConfigureMassTransit<VesselDbContext>("vessel-api");

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

DbHelpers.ApplyPendingMigrations<VesselDbContext>(app.Services);

app.Run();