using Microsoft.Extensions.Configuration;

namespace SurveyService;

public static class Extensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddEndpointsApiExplorer();
        services.AddControllers();

        services.AddSingleton(_ => new SurveyDbContextFactory(config["ConnectionString"]));

        services.AddSwaggerGen();

        return services;
    }

    public static WebApplication ConfigureApplicationServices(this WebApplication app)
    {
        app.MapControllers();

        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
}