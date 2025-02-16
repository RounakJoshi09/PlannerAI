using Contracts;
using LoggerService;

namespace PlannerAI.ServiceExtension
{
    public static class ServiceExtension
    {
        public static void ConfigureCORS(this IServiceCollection services) => services.AddCors(option => option.AddPolicy("CorsPolicy", builder =>
        {
            builder.AllowAnyMethod()
                .AllowAnyHeader()
                .AllowAnyOrigin()
                .WithOrigins("http://localhost:3000")
                .AllowCredentials();
        }));

        public static void ConfigureIISServerOptions(this IServiceCollection services) => services.Configure<IISServerOptions>(option =>
        {
        });

        public static void ConfigureLoggerService(this IServiceCollection services) => services.AddSingleton<ILoggerManager, LoggerManager>();
    }
}