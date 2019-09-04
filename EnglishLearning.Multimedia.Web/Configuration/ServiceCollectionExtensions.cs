using EnglishLearning.Multimedia.Web.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishLearning.Multimedia.Web.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWebConfiguration(this IServiceCollection services)
        {
            services.AddSingleton(new WebMapper());
            
            return services;
        }
    }
}