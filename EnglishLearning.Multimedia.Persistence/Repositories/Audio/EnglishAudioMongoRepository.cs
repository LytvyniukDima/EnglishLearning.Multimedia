using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Multimedia.Persistence.Abstract;
using EnglishLearning.Multimedia.Persistence.Entities;
using EnglishLearning.Multimedia.Persistence.Entities.Audio;
using EnglishLearning.Utilities.Persistence.Mongo.Contexts;
using EnglishLearning.Utilities.Persistence.Mongo.Repositories;
using MongoDB.Driver;

namespace EnglishLearning.Multimedia.Persistence.Repositories.Audio
{
    public class EnglishAudioMongoRepository : BaseStringIdWithInfoModelRepository<EnglishAudio, EnglishAudioInfo>, IEnglishAudioRepository
    {
        public EnglishAudioMongoRepository(MongoContext dbContext) : base(dbContext)
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
                    AudioPlayerType = x.AudioPlayerType
                });
            
        }

        public async Task<IReadOnlyList<EnglishAudio>> FindAllByPhrase(string phrase)
        {
            return await _collection.Find(x => x.Tittle.Contains(phrase) || x.Transcription.Contains(phrase)).ToListAsync();
        }

        public async Task<IReadOnlyList<EnglishAudio>> FindAllByFilters(string[] audioTypes, EnglishLevel[] englishLevels)
        {
            var builder = Builders<EnglishAudio>.Filter;
            var filter = builder.In(x => x.AudioType, audioTypes) &
                builder.In(x => x.EnglishLevel, englishLevels);
            
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<IReadOnlyList<EnglishAudio>> FindAllByFilters(string phrase, string[] audioTypes, EnglishLevel[] englishLevels)
        {
            var builder = Builders<EnglishAudio>.Filter;
            var filter = builder.In(x => x.AudioType, audioTypes) &
                         builder.In(x => x.EnglishLevel, englishLevels) &
                         builder.Or(Builders<EnglishAudio>.Filter.Regex(x => x.Tittle, phrase), 
                             Builders<EnglishAudio>.Filter.Regex(x => x.Transcription, phrase));
            
            return await _collection.Find(filter).ToListAsync(); 
        }

        public async Task<IReadOnlyList<EnglishAudioInfo>> FindAllInfoByPhrase(string phrase)
        {
            return await _collection
                .Find(x => x.Tittle.Contains(phrase) || x.Transcription.Contains(phrase))
                .Project(InfoModelProjectionDefinition)    
                .ToListAsync();
        }

        public async Task<IReadOnlyList<EnglishAudioInfo>> FindAllInfoByFilters(string[] audioTypes, EnglishLevel[] englishLevels)
        {
            var builder = Builders<EnglishAudio>.Filter;
            var filter = builder.In(x => x.AudioType, audioTypes) &
                builder.In(x => x.EnglishLevel, englishLevels);
            
            return await _collection
                .Find(filter)
                .Project(InfoModelProjectionDefinition)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<EnglishAudioInfo>> FindAllInfoByFilters(string phrase, string[] audioTypes, EnglishLevel[] englishLevels)
        {
            var builder = Builders<EnglishAudio>.Filter;
            var filter = builder.In(x => x.AudioType, audioTypes) &
                         builder.In(x => x.EnglishLevel, englishLevels) &
                         builder.Or(Builders<EnglishAudio>.Filter.Regex(x => x.Tittle, phrase), Builders<EnglishAudio>.Filter.Regex(x => x.Transcription, phrase));
            
            return await _collection
                .Find(filter)
                .Project(InfoModelProjectionDefinition)
                .ToListAsync();
        }
    }
}
