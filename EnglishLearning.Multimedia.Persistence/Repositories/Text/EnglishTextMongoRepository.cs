using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Multimedia.Persistence.Abstract;
using EnglishLearning.Multimedia.Persistence.Entities;
using EnglishLearning.Multimedia.Persistence.Entities.Audio;
using EnglishLearning.Multimedia.Persistence.Entities.Text;
using EnglishLearning.Utilities.Linq.Extensions;
using EnglishLearning.Utilities.Persistence.Mongo.Contexts;
using EnglishLearning.Utilities.Persistence.Mongo.Repositories;
using MongoDB.Driver;

namespace EnglishLearning.Multimedia.Persistence.Repositories.Text
{
    public class EnglishTextMongoRepository : BaseStringIdWithInfoModelRepository<EnglishText, EnglishTextInfo>, IEnglishTextRepository
    {
        public EnglishTextMongoRepository(MongoContext dbContext) : base(dbContext)
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

        public async Task<IReadOnlyList<EnglishText>> FindAllByFilters(string phrase, string[] textTypes, EnglishLevel[] englishLevels)
        {
            var builder = Builders<EnglishText>.Filter;
            var filter = builder.Empty;

            if (!String.IsNullOrEmpty(phrase))
            {
                filter = builder.Or(Builders<EnglishText>.Filter.Regex(x => x.HeadLine, phrase), 
                    Builders<EnglishText>.Filter.Regex(x => x.Text, phrase));
            }
            if (!textTypes.IsNullOrEmpty())
                filter &= builder.In(x => x.TextType, textTypes);
            if (!englishLevels.IsNullOrEmpty())
                filter &= builder.In(x => x.EnglishLevel, englishLevels);
            
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<IReadOnlyList<EnglishTextInfo>> FindAllInfoByFilters(string phrase, string[] textTypes, EnglishLevel[] englishLevels)
        {
            var builder = Builders<EnglishText>.Filter;
            var filter = builder.Empty;

            if (!String.IsNullOrEmpty(phrase))
            {
                filter = builder.Or(Builders<EnglishText>.Filter.Regex(x => x.HeadLine, phrase), 
                    Builders<EnglishText>.Filter.Regex(x => x.Text, phrase));
            }
            if (!textTypes.IsNullOrEmpty())
                filter &= builder.In(x => x.TextType, textTypes);
            if (!englishLevels.IsNullOrEmpty())
                filter &= builder.In(x => x.EnglishLevel, englishLevels);
            
            return await _collection
                .Find(filter)
                .Project(InfoModelProjectionDefinition)
                .ToListAsync();
        }
    }
}
