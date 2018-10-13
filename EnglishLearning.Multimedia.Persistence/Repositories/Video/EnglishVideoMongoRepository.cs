using EnglishLearning.Multimedia.Persistence.Abstract;
using EnglishLearning.Multimedia.Persistence.Entities.Video;

namespace EnglishLearning.Multimedia.Persistence.Repositories.Video
{
    public class EnglishVideoMongoRepository : BaseMongoDbRepository<EnglishVideo>
    {
        private const string collectionName = "EnglishMultimedia_EnglishVideo";

        public EnglishVideoMongoRepository(IMultimediaDbContext dbContext) : base(dbContext, collectionName)
        {
            
        }
    }
}