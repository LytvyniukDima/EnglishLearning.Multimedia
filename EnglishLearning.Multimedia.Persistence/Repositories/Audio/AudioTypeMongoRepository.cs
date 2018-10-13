using EnglishLearning.Multimedia.Persistence.Abstract;
using EnglishLearning.Multimedia.Persistence.Entities.Audio;

namespace EnglishLearning.Multimedia.Persistence.Repositories.Audio
{
    public class AudioTypeMongoRepository : BaseMongoDbRepository<AudioType>
    {
        private const string collectionName = "EnglishMultimedia_AudioType";

        public AudioTypeMongoRepository(IMultimediaDbContext dbContext) : base(dbContext, collectionName)
        {
            
        }
    }
}