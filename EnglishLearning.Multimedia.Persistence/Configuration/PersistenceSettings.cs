using EnglishLearning.Multimedia.Persistence.Abstract;
using EnglishLearning.Multimedia.Persistence.Repositories.Audio;
using EnglishLearning.Multimedia.Persistence.Repositories.Text;
using EnglishLearning.Multimedia.Persistence.Repositories.Video;
using EnglishLearning.Utilities.Configurations.MongoConfiguration;
using EnglishLearning.Utilities.Persistence.Mongo.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishLearning.Multimedia.Persistence.Configuration
{
    public static class PersistenceSettings
    {
        public static IServiceCollection PersistenceConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMongoConfiguration(configuration);
            services.AddMongoDependencies();
            
            services.AddTransient<IEnglishAudioRepository, EnglishAudioMongoRepository>();
            services.AddTransient<IEnglishTextRepository, EnglishTextMongoRepository>();
            services.AddTransient<IEnglishVideoRepository, EnglishVideoMongoRepository>();
            
            return services;
        }
    }
}