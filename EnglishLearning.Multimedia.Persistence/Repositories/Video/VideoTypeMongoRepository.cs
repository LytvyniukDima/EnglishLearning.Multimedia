using EnglishLearning.Multimedia.Persistence.Abstract;
using EnglishLearning.Multimedia.Persistence.Entities.Video;

namespace EnglishLearning.Multimedia.Persistence.Repositories.Video
{
    public class VideoTypeMongoRepository : BaseMongoDbRepository<VideoType>
    {
        private const string collectionName = "EnglishMultimedia_VideoType";

        public VideoTypeMongoRepository(IMultimediaDbContext dbContext) : base(dbContext, collectionName)
        {
            
        }
    }
}