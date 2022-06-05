using MusicLibrary.Data;
using MusicLibrary.DataInterfaces;
using MusicLibrary.Project.Builders;
using MusicLibrary.Project.Builders.Interfaces;
using MusicLibrary.Project.Handlers;
using MusicLibrary.Project.Handlers.Interfaces;
using MusicLibrary.ServiceInterfaces;
using MusicLibrary.Services;
using MusicLibrary.Services.Handlers;
using MusicLibrary.Services.Handlers.Interfaces;

namespace TestProj
{
    public static class CustomExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IMediaHandler, MediaHandler>();
            services.AddScoped<IMediaResourceBuilder, MediaResourceBuilder>();
            services.AddScoped<IMediaService, MediaService>();
            services.AddScoped<IMediaServiceHandler, MediaServiceHandler>();
            services.AddScoped<IMediaRepository, MediaRepository>();
            return services;
        }
    }
}
