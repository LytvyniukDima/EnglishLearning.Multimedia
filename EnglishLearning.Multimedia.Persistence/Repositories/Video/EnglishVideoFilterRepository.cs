using System.Linq;
using EnglishLearning.Multimedia.Persistence.Abstract;
using EnglishLearning.Multimedia.Persistence.Entities;
using EnglishLearning.Multimedia.Persistence.Entities.Video;
using EnglishLearning.Utilities.Persistence.Mongo.Contexts;
using MongoDB.Driver;

namespace EnglishLearning.Multimedia.Persistence.Repositories.Video
{
    public class EnglishVideoFilterRepository : IEnglishVideoFiltersRepository
    {
        protected readonly MongoContext _dbContext;
        protected readonly IMongoCollection<EnglishVideo> _collection;
        
        public EnglishVideoFilterRepository(MongoContext dbContext)
        {
            _dbContext = dbContext;
            _collection = _dbContext.GetCollection<EnglishVideo>();
        }
        
        public VideoTypeFilter GetVideoTypeFilter()
        {
            var filterOptions = _collection
                .Aggregate()
                .Group(x => x.VideoType, group => new
                {
                    Key = group.Key,
                    Value = group.Count()
                })
                .ToEnumerable()
                .ToDictionary(x => x.Key ?? string.Empty, x => x.Value);

            var videoTypeFilter = new VideoTypeFilter { FilterOptions = filterOptions };
            
            return videoTypeFilter;
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

        public EnglishVideoFullFilter GetEnglishVideoFullFilter()
        {
            var englishVideoFullFilter = new EnglishVideoFullFilter
            {
                VideoTypeFilterResult = GetVideoTypeFilter(),
                EnglishLevelFilterResult = GetEnglishLevelFilter()
            };

            return englishVideoFullFilter;
        }
    }
}
