using EnglishLearning.Multimedia.Persistence.Abstract;
using EnglishLearning.Multimedia.Persistence.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishLearning.Multimedia.Persistence.Configuration
{
    public static class PersistenceSettings
    {
        public static IServiceCollection PersistenceConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDbConfiguration>(configuration.GetSection("MongoDbConfiguration"));

            services.AddScoped<IMultimediaDbContext, MultimediaDbContext>();
            //services.AddTransient<IMongoDbRepository<EnglishTask>, EnglishTaskMongoDbRepository>();
            
            return services;
        }
    }
}