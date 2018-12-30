using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Multimedia.Persistence.Abstract;
using EnglishLearning.Multimedia.Persistence.Entities;
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

        public async Task<IReadOnlyList<EnglishVideo>> FindAllByPhrase(string phrase)
        {
            return await _collection.Find(x => x.Title.Contains(phrase) || x.Transcription.Contains(phrase)).ToListAsync();
        }

        public async Task<IReadOnlyList<EnglishVideo>> FindAllByFilters(string[] videoTypes, EnglishLevel[] englishLevels)
        {
            var builder = Builders<EnglishVideo>.Filter;
            var filter = builder.In(x => x.VideoType, videoTypes) &
                         builder.In(x => x.EnglishLevel, englishLevels);
            
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<IReadOnlyList<EnglishVideoInfo>> FindAllInfoByPhrase(string phrase)
        {
            return await _collection
                .Find(x => x.Title.Contains(phrase) || x.Transcription.Contains(phrase))
                .Project(InfoModelProjectionDefinition)    
                .ToListAsync();
        }

        public async Task<IReadOnlyList<EnglishVideoInfo>> FindAllInfoByFilters(string[] videoTypes, EnglishLevel[] englishLevels)
        {
            var builder = Builders<EnglishVideo>.Filter;
            var filter = builder.In(x => x.VideoType, videoTypes) &
                         builder.In(x => x.EnglishLevel, englishLevels);
            
            return await _collection
                .Find(filter)
                .Project(InfoModelProjectionDefinition)
                .ToListAsync();
        }
    }
}
