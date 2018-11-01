using EnglishLearning.Multimedia.Persistence.Abstract;
using EnglishLearning.Multimedia.Persistence.Entities.Text;
using MongoDB.Driver;

namespace EnglishLearning.Multimedia.Persistence.Repositories.Text
{
    public class EnglishTextMongoRepository : BaseMongoDbRepository<EnglishText, EnglishTextInfo>, IEnglishTextRepository
    {
        private const string collectionName = "EnglishMultimedia_EnglishText";

        public EnglishTextMongoRepository(IMultimediaDbContext dbContext) : base(dbContext, collectionName)
        {
            
        }

        protected override ProjectionDefinition<EnglishText, EnglishTextInfo> TInfoProjection
        {
            get => Builders<EnglishText>
                .Projection
                .Expression(x => new EnglishTextInfo
                {
                    Id = x.Id,
                    HeadLine = x.HeadLine,
                    TextType = x.TextType,
                    EnglishLevel = x.EnglishLevel
                });
        }
    }
}
