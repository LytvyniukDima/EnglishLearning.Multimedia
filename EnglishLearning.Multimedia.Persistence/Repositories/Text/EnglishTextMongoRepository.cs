using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Multimedia.Persistence.Abstract;
using EnglishLearning.Multimedia.Persistence.Entities;
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

        public async Task<IReadOnlyList<EnglishText>> FindAllByPhrase(string phrase)
        {
            return await _collection.Find(x => x.HeadLine.Contains(phrase) || x.Text.Contains(phrase)).ToListAsync();
        }

        public async Task<IReadOnlyList<EnglishText>> FindAllByFilters(string[] textTypes, EnglishLevel[] englishLevels)
        {
            var builder = Builders<EnglishText>.Filter;
            var filter = builder.In(x => x.TextType, textTypes) &
                         builder.In(x => x.EnglishLevel, englishLevels);
            
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<IReadOnlyList<EnglishTextInfo>> FindAllInfoByPhrase(string phrase)
        {
            return await _collection
                .Find(x => x.HeadLine.Contains(phrase) || x.Text.Contains(phrase))
                .Project(InfoModelProjectionDefinition)    
                .ToListAsync();
        }

        public async Task<IReadOnlyList<EnglishTextInfo>> FindAllInfoByFilters(string[] textTypes, EnglishLevel[] englishLevels)
        {
            var builder = Builders<EnglishText>.Filter;
            var filter = builder.In(x => x.TextType, textTypes) &
                         builder.In(x => x.EnglishLevel, englishLevels);
            
            return await _collection
                .Find(filter)
                .Project(InfoModelProjectionDefinition)
                .ToListAsync();
        }
    }
}
