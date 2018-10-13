using EnglishLearning.Multimedia.Persistence.Abstract;
using EnglishLearning.Multimedia.Persistence.Entities.Text;

namespace EnglishLearning.Multimedia.Persistence.Repositories.Text
{
    public class TextTypeMongoRepository : BaseMongoDbRepository<TextType>
    {
        private const string collectionName = "EnglishMultimedia_TextType";

        public TextTypeMongoRepository(IMultimediaDbContext dbContext) : base(dbContext, collectionName)
        {
            
        }
    }
}