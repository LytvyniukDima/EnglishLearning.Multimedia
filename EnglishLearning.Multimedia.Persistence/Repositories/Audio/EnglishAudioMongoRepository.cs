using EnglishLearning.Multimedia.Persistence.Abstract;
using EnglishLearning.Multimedia.Persistence.Entities.Audio;
using EnglishLearning.Utilities.Persistence.Mongo.Contexts;
using EnglishLearning.Utilities.Persistence.Mongo.Repositories;
using MongoDB.Driver;

namespace EnglishLearning.Multimedia.Persistence.Repositories.Audio
{
    public class EnglishAudioMongoRepository : BaseStringIdWithInfoModelRepository<EnglishAudio, EnglishAudioInfo>, IEnglishAudioRepository
    {
        private const string collectionName = "EnglishMultimedia_EnglishAudio";

        public EnglishAudioMongoRepository(MongoContext dbContext) : base(dbContext, collectionName)
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
    }
}