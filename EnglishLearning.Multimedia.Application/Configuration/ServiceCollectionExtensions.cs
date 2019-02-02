using EnglishLearning.Multimedia.Application.Abstract;
using EnglishLearning.Multimedia.Application.Infrastructure;
using EnglishLearning.Multimedia.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishLearning.Multimedia.Application.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(new ApplicationMapper());

            services.AddScoped<IAudioService, AudioService>();
            services.AddScoped<ITextService, TextService>();
            services.AddScoped<IVideoService, VideoService>();
            
            return services;
        }
    }
}