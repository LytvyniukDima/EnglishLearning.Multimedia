using EnglishLearning.Multimedia.Persistence.Abstract;
using EnglishLearning.Multimedia.Persistence.Entities.Video;
using MongoDB.Driver;

namespace EnglishLearning.Multimedia.Persistence.Repositories.Video
{
    public class EnglishVideoMongoRepository : BaseMongoDbRepository<EnglishVideo, EnglishVideoInfo>, IEnglishVideoRepository
    {
        private const string collectionName = "EnglishMultimedia_EnglishVideo";

        public EnglishVideoMongoRepository(IMultimediaDbContext dbContext) : base(dbContext, collectionName)
        {
            
        }

        protected override ProjectionDefinition<EnglishVideo, EnglishVideoInfo> TInfoProjection
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