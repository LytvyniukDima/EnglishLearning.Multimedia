using EnglishLearning.Multimedia.Application.Abstract;
using EnglishLearning.Multimedia.Application.Abstract.Filters;
using EnglishLearning.Multimedia.Application.Abstract.Random;
using EnglishLearning.Multimedia.Application.Infrastructure;
using EnglishLearning.Multimedia.Application.Services;
using EnglishLearning.Multimedia.Application.Services.Filters;
using EnglishLearning.Multimedia.Application.Services.Random;
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

            services.AddScoped<IEnglishAudioFilterService, EnglishAudioFilterService>();
            services.AddScoped<IEnglishTextFilterService, EnglishTextFilterService>();
            services.AddScoped<IEnglishVideoFilterService, EnglishVideoFilterService>();

            services.AddScoped<IRandomAudioInfoService, RandomAudioInfoService>();
            services.AddScoped<IRandomTextInfoService, RandomTextInfoService>();
            services.AddScoped<IRandomVideoInfoService, RandomVideoInfoService>();

            services.AddScoped<IRandomAudioService, RandomAudioService>();
            services.AddScoped<IRandomTextService, RandomTextService>();
            services.AddScoped<IRandomVideoService, RandomVideoService>();
            
            return services;
        }
    }
}