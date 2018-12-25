﻿using EnglishLearning.Multimedia.Persistence.Abstract;
using EnglishLearning.Multimedia.Persistence.Contexts;
using EnglishLearning.Multimedia.Persistence.Entities.Audio;
using EnglishLearning.Multimedia.Persistence.Entities.Text;
using EnglishLearning.Multimedia.Persistence.Entities.Video;
using EnglishLearning.Multimedia.Persistence.Repositories.Audio;
using EnglishLearning.Multimedia.Persistence.Repositories.Text;
using EnglishLearning.Multimedia.Persistence.Repositories.Video;
using EnglishLearning.Utilities.Configurations.MongoConfiguration;
using EnglishLearning.Utilities.Persistence.Mongo.Configuration;
using EnglishLearning.Utilities.Persistence.Mongo.Interfaces;
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