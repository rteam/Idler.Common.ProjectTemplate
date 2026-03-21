using CRTVUP.Unify.Common.ShortLink.API.Startups;
using Idler.Common.AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLog;
using NLog.Web;
using System.Reflection;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.Configure<ApiBehaviorOptions>(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });
    builder.Services.AddOpenApi("v1");
    builder.Services.AddSwaggerGen(options =>
    {
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        if (File.Exists(xmlPath))
        {
            options.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
        }
    });
    builder.Services.AddAutoMapper();
    builder.AddCache();
    builder.Host.AddAutofac();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.MapOpenApi();
        app.MapOpenApi("/openapi/{documentName}.yaml");
    }

    app.UseHttpsRedirection();

    app.MapControllers();

    app.UseAutoMapper();

    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "应用程序因异常停止了运行");
    throw;
}
finally
{
    NLog.LogManager.Shutdown();
}

public partial class Program;
