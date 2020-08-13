using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Multimedia.Persistence.Abstract;
using EnglishLearning.Multimedia.Persistence.Entities;
using EnglishLearning.Multimedia.Persistence.Entities.Video;
using EnglishLearning.Utilities.Linq.Extensions;
using EnglishLearning.Utilities.Persistence.Mongo.Contexts;
using EnglishLearning.Utilities.Persistence.Mongo.Repositories;
using MongoDB.Driver;

namespace EnglishLearning.Multimedia.Persistence.Repositories.Video
{
    public class EnglishVideoMongoRepository : BaseMongoWithInfoModelRepository<EnglishVideo, EnglishVideoInfo, string>, IEnglishVideoRepository
    {
        public EnglishVideoMongoRepository(MongoContext mongoContext) 
            : base(mongoContext)
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
                    EnglishLevel = x.EnglishLevel,
                });
        }

        public async Task<IReadOnlyList<EnglishVideo>> FindAllByFilters(string phrase, string[] videoTypes, EnglishLevel[] englishLevels)
        {
            var filter = BuildFilter(phrase, videoTypes, englishLevels);

            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<IReadOnlyList<EnglishVideoInfo>> FindAllInfoByFilters(string phrase, string[] videoTypes, EnglishLevel[] englishLevels)
        {
            var filter = BuildFilter(phrase, videoTypes, englishLevels);

            return await _collection
                .Find(filter)
                .Project(InfoModelProjectionDefinition)
                .ToListAsync();
        }

        private FilterDefinition<EnglishVideo> BuildFilter(string phrase, string[] videoTypes, EnglishLevel[] englishLevels)
        {
            var builder = Builders<EnglishVideo>.Filter;
            var filter = builder.Empty;

            if (!string.IsNullOrEmpty(phrase))
            {
                filter = builder.Or(
                    Builders<EnglishVideo>.Filter.Regex(x => x.Title, phrase), 
                    Builders<EnglishVideo>.Filter.Regex(x => x.Transcription, phrase));
            }
            
            if (!videoTypes.IsNullOrEmpty())
            {
                filter &= builder.In(x => x.VideoType, videoTypes);
            }

            if (!englishLevels.IsNullOrEmpty())
            {
                filter &= builder.In(x => x.EnglishLevel, englishLevels);
            }

            return filter;
        }
    }
}
