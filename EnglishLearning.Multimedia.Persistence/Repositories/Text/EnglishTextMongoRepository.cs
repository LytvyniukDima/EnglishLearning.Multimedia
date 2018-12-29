using EnglishLearning.Multimedia.Persistence.Abstract;
using EnglishLearning.Multimedia.Persistence.Entities.Text;
using EnglishLearning.Utilities.Persistence.Mongo.Contexts;
using EnglishLearning.Utilities.Persistence.Mongo.Repositories;
using MongoDB.Driver;

namespace EnglishLearning.Multimedia.Persistence.Repositories.Text
{
    public class EnglishTextMongoRepository : BaseStringIdWithInfoModelRepository<EnglishText, EnglishTextInfo>, IEnglishTextRepository
    {
        private const string collectionName = "EnglishMultimedia_EnglishText";

        public EnglishTextMongoRepository(MongoContext dbContext) : base(dbContext, collectionName)
        {
            
        }

        protected override ProjectionDefinition<EnglishText, EnglishTextInfo> InfoModelProjectionDefinition
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
