﻿using GloboTicket.TicketManagement.Api.Services;
using GloboTicket.TicketManagement.Application;
using GloboTicket.TicketManagement.Application.Contracts;
using GloboTicket.TicketManagement.Infrastructure;
using GloboTicket.TicketManagement.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GloboTicket.TicketManagement.Api
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigureServices(
            this WebApplicationBuilder builder)
        {
            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(builder.Configuration); // Corrected method name
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddScoped<ILoggedInUserService, LoggedInUserService>();
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddControllers();

            // Configurarea CORS
            builder.Services.AddCors(options => options.AddPolicy(
                "open",
                policy => policy.WithOrigins(
                        builder.Configuration["ApiUrl"] ?? "https://localhost:7020",
                        builder.Configuration["BlazorUrl"] ?? "https://localhost:7080")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()));

            // Configurarea DbContext
            builder.Services.AddDbContext<GloboTicketDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("GloboTicketManagementConnectionString")));

            builder.Services.AddSwaggerGen();

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseCors("open");

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.MapControllers();

            return app;
        }

        public static async Task ResetDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            try
            {
                var context = scope.ServiceProvider.GetService<GloboTicketDbContext>();
                if (context != null)
                {
                    await context.Database.EnsureCreatedAsync();
                    await context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                // Add logging here later on
            }
        }
    }
}
