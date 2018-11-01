using EnglishLearning.Multimedia.Persistence.Abstract;
using EnglishLearning.Multimedia.Persistence.Contexts;
using EnglishLearning.Multimedia.Persistence.Entities.Audio;
using EnglishLearning.Multimedia.Persistence.Entities.Text;
using EnglishLearning.Multimedia.Persistence.Entities.Video;
using EnglishLearning.Multimedia.Persistence.Repositories.Audio;
using EnglishLearning.Multimedia.Persistence.Repositories.Text;
using EnglishLearning.Multimedia.Persistence.Repositories.Video;
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
            
            services.AddTransient<IRepository<EnglishAudio>, EnglishAudioMongoRepository>();
            services.AddTransient<IRepository<EnglishText>, EnglishTextMongoRepository>();
            services.AddTransient<IRepository<EnglishVideo>, EnglishVideoMongoRepository>();
            
            return services;
        }
    }
}