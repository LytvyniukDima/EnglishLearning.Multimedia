using EnglishLearning.Multimedia.Persistence.Abstract;
using EnglishLearning.Multimedia.Persistence.Entities.Text;

namespace EnglishLearning.Multimedia.Persistence.Repositories.Text
{
    public class EnglishTextMongoRepository : BaseMongoDbRepository<EnglishText>
    {
        private const string collectionName = "EnglishMultimedia_EnglishText";

        public EnglishTextMongoRepository(IMultimediaDbContext dbContext) : base(dbContext, collectionName)
        {
            
        }
    }
}
