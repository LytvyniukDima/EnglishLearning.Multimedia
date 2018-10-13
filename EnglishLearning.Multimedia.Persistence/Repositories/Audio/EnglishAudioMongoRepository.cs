using EnglishLearning.Multimedia.Persistence.Abstract;
using EnglishLearning.Multimedia.Persistence.Entities.Audio;

namespace EnglishLearning.Multimedia.Persistence.Repositories.Audio
{
    public class EnglishAudioMongoRepository : BaseMongoDbRepository<EnglishAudio>
    {
        private const string collectionName = "EnglishMultimedia_EnglishAudio";

        public EnglishAudioMongoRepository(IMultimediaDbContext dbContext) : base(dbContext, collectionName)
        {
            
        }
    }
}