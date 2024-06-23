﻿using MassTransit;
using Microsoft.EntityFrameworkCore;
using RS.FleetAdmin.Shared.Messaging;
using RS.FleetAdmin.StationAPI.Entities;

namespace RS.FleetAdmin.StationAPI.DATA;

public class StationDbContext(DbContextOptions options) : OutboxDbContext(options)
{
    public DbSet<Station> Stations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}