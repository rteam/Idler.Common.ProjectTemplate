using BaseMicroService.API.Startups;
using Idler.Common.AutoMapper;
using NLog;
using NLog.Web;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddAutoMapper();
#if (Cache)
    builder.AddCache();
#endif
    builder.Host.AddAutofac();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
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