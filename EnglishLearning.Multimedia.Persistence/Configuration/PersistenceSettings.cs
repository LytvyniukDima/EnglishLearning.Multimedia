using EnglishLearning.Multimedia.Persistence.Abstract;
using EnglishLearning.Multimedia.Persistence.Entities.Audio;
using EnglishLearning.Multimedia.Persistence.Entities.Text;
using EnglishLearning.Multimedia.Persistence.Entities.Video;
using EnglishLearning.Multimedia.Persistence.Repositories.Audio;
using EnglishLearning.Multimedia.Persistence.Repositories.Text;
using EnglishLearning.Multimedia.Persistence.Repositories.Video;
using EnglishLearning.Utilities.Configurations.MongoConfiguration;
using EnglishLearning.Utilities.Persistence.Mongo.Configuration;
using EnglishLearning.Utilities.Persistence.Redis.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace EnglishLearning.Multimedia.Persistence.Configuration
{
    public static class PersistenceSettings
    {
        public static IServiceCollection PersistenceConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddMongoConfiguration(configuration)    
                .AddMongoContext(options =>
                {
                    options.HasIndex<EnglishAudio>(index =>
                        {
                            index.CreateOne(new CreateIndexModel<EnglishAudio>(Builders<EnglishAudio>.IndexKeys.Ascending(x => x.Tittle)));
                            index.CreateMany(new[]
                            {
                                new CreateIndexModel<EnglishAudio>(
                                    Builders<EnglishAudio>.IndexKeys.Text(x => x.Transcription)),
                                new CreateIndexModel<EnglishAudio>(
                                    Builders<EnglishAudio>.IndexKeys.Ascending(x => x.Tittle)),
                            });
                        });
                })
                .AddMongoCollectionNamesProvider(x => 
                {
                    x.Add<EnglishAudio>("EnglishMultimedia_EnglishAudio");
                    x.Add<EnglishVideo>( "EnglishMultimedia_EnglishVideo");
                    x.Add<EnglishText>("EnglishMultimedia_EnglishText");
                });
            
            services.AddTransient<IEnglishAudioRepository, EnglishAudioMongoRepository>();
            services.AddTransient<IEnglishTextRepository, EnglishTextMongoRepository>();
            services.AddTransient<IEnglishVideoRepository, EnglishVideoMongoRepository>();

            services.AddTransient<IEnglishAudioFiltersRepository, EnglishAudioFilterRepository>();
            services.AddTransient<IEnglishTextFiltersRepository, EnglishTextFilterRepository>();
            services.AddTransient<IEnglishVideoFiltersRepository, EnglishVideoFilterRepository>();

            services.AddRedis(configuration);
            
            return services;
        }
    }
}
