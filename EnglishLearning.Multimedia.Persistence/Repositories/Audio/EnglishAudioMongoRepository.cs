using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Multimedia.Persistence.Abstract;
using EnglishLearning.Multimedia.Persistence.Entities;
using EnglishLearning.Multimedia.Persistence.Entities.Audio;
using EnglishLearning.Utilities.Linq.Extensions;
using EnglishLearning.Utilities.Persistence.Mongo.Contexts;
using EnglishLearning.Utilities.Persistence.Mongo.Repositories;
using MongoDB.Driver;

namespace EnglishLearning.Multimedia.Persistence.Repositories.Audio
{
    public class EnglishAudioMongoRepository : BaseStringIdWithInfoModelRepository<EnglishAudio, EnglishAudioInfo>, IEnglishAudioRepository
    {
        public EnglishAudioMongoRepository(MongoContext mongoContext) 
            : base(mongoContext)
        {
        }

        protected override ProjectionDefinition<EnglishAudio, EnglishAudioInfo> InfoModelProjectionDefinition
        {
            get => Builders<EnglishAudio>
                .Projection
                .Expression(x => new EnglishAudioInfo
                {
                    Id = x.Id,
                    Tittle = x.Tittle,
                    Duration = x.Duration,
                    AudioType = x.AudioType,
                    EnglishLevel = x.EnglishLevel,
                    AudioPlayerType = x.AudioPlayerType,
                });
        }

        public async Task<IReadOnlyList<EnglishAudio>> FindAllByFilters(string phrase, string[] audioTypes, EnglishLevel[] englishLevels)
        {
            var filter = BuildFilter(phrase, audioTypes, englishLevels);

            return await _collection.Find(filter).ToListAsync(); 
        }

        public async Task<IReadOnlyList<EnglishAudioInfo>> FindAllInfoByFilters(string phrase, string[] audioTypes, EnglishLevel[] englishLevels)
        {
            var filter = BuildFilter(phrase, audioTypes, englishLevels);

            return await _collection
                .Find(filter)
                .Project(InfoModelProjectionDefinition)
                .ToListAsync();
        }

        public FilterDefinition<EnglishAudio> BuildFilter(string phrase, string[] audioTypes, EnglishLevel[] englishLevels)
        {
            var builder = Builders<EnglishAudio>.Filter;
            var filter = builder.Empty;

            if (!string.IsNullOrEmpty(phrase))
            {
                filter = builder.Or(
                    Builders<EnglishAudio>.Filter.Regex(x => x.Tittle, phrase),
                    Builders<EnglishAudio>.Filter.Regex(x => x.Transcription, phrase));
            }
            
            if (!audioTypes.IsNullOrEmpty())
            {
                filter &= builder.In(x => x.AudioType, audioTypes);
            }

            if (!englishLevels.IsNullOrEmpty())
            {
                filter &= builder.In(x => x.EnglishLevel, englishLevels);
            }

            return filter;
        }
    }
}
