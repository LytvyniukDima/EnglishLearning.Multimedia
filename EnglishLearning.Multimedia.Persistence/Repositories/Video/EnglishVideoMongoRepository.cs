﻿using EnglishLearning.Multimedia.Persistence.Abstract;
using EnglishLearning.Multimedia.Persistence.Entities.Video;
using EnglishLearning.Utilities.Persistence.Mongo.Contexts;
using EnglishLearning.Utilities.Persistence.Mongo.Repositories;
using MongoDB.Driver;

namespace EnglishLearning.Multimedia.Persistence.Repositories.Video
{
    public class EnglishVideoMongoRepository : BaseStringIdWithInfoModelRepository<EnglishVideo, EnglishVideoInfo>, IEnglishVideoRepository
    {
        private const string collectionName = "EnglishMultimedia_EnglishVideo";

        public EnglishVideoMongoRepository(MongoContext dbContext) : base(dbContext, collectionName)
        {
            
        }

        protected override ProjectionDefinition<EnglishVideo, EnglishVideoInfo> InfoModelProjectionDefinition
        {
            get => Builders<EnglishVideo>
                .Projection
                .Expression(x => new EnglishVideoInfo
                {
                    Id = x.Id,
                    Title = x.Title,
                    VideoType = x.VideoType,
                    EnglishLevel = x.EnglishLevel
                });
        }
    }
}
