using Cosmos.AspNetCore;
using Cosmos.AspNetCore.Exceptions;
using Cosmos.Configuration;
using Cosmos.Logging.Serilog;
using BranchPromotion.Application;
using BranchPromotion.Infrastructure;
using Microsoft.OpenApi.Models;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

var services = builder.Services;
var configuration = builder.Configuration;
var env = builder.Environment;

services.AddCosmosAspNetCore(configuration, env);

services.AddApplicationServices(configuration);
services.AddInfrastructureServices(configuration);

services.AddControllers();
services.AddExceptionHandler<CustomExceptionHandler>();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "BranchPromotion API",
        Version = "v1"
    });
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "BranchPromotion.Api.xml"));
});

void App()
{
    var app = builder.Build();

    app.UseExceptionHandler(_ => { });

    app.ConfigureMinThreads();
    app.ConfigureCosmosSerilogLogger();

    app.UseSwagger();

    app.UseRouting();
    app.MapControllers();

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BranchPromotion API V1");
        c.RoutePrefix = "";
        c.DocExpansion(DocExpansion.None);
    });

    app.Run();
}

Bootstrapper.Run<SerilogBootstrapLogger>(App);
