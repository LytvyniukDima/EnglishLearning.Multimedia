using System.Linq;
using EnglishLearning.Multimedia.Persistence.Abstract;
using EnglishLearning.Multimedia.Persistence.Entities;
using EnglishLearning.Multimedia.Persistence.Entities.Text;
using EnglishLearning.Utilities.Persistence.Mongo.Contexts;
using MongoDB.Driver;

namespace EnglishLearning.Multimedia.Persistence.Repositories.Text
{
    public class EnglishTextFilterRepository : IEnglishTextFiltersRepository
    {
        protected readonly MongoContext _dbContext;
        protected readonly IMongoCollection<EnglishText> _collection;
        
        public EnglishTextFilterRepository(MongoContext dbContext)
        {
            _dbContext = dbContext;
            _collection = _dbContext.GetCollection<EnglishText>();
        }
        
        public TextTypeFilter GetTextTypeFilter()
        {
            var filterOptions = _collection
                .Aggregate()
                .Group(x => x.TextType, group => new
                {
                    Key = group.Key,
                    Value = group.Count()
                })
                .ToEnumerable()
                .ToDictionary(x => x.Key, x => x.Value);

            var textTypeFilter = new TextTypeFilter { FilterOptions = filterOptions };
            
            return textTypeFilter;
        }

        public EnglishLevelFilter GetEnglishLevelFilter()
        {
            var filterOptions = _collection
                .Aggregate()
                .Group(x => x.EnglishLevel, group => new
                {
                    Key = group.Key,
                    Value = group.Count()
                })
                .ToEnumerable()
                .ToDictionary(x => x.Key, x => x.Value);

            var englishLevelFilter = new EnglishLevelFilter { FilterOptions = filterOptions };
            
            return englishLevelFilter;
        }

        public EnglishTextFullFilter GetEnglishTextFullFilter()
        {
            var englishTextFullFilter = new EnglishTextFullFilter
            {
                TextTypeFilterOptions = GetTextTypeFilter(),
                EnglishLevelFilterOptions = GetEnglishLevelFilter()
            };

            return englishTextFullFilter;
        }
    }
}
