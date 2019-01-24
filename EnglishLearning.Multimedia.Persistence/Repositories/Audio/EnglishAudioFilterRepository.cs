using System.Linq;
using EnglishLearning.Multimedia.Persistence.Abstract;
using EnglishLearning.Multimedia.Persistence.Entities;
using EnglishLearning.Multimedia.Persistence.Entities.Audio;
using EnglishLearning.Utilities.Persistence.Mongo.Contexts;
using MongoDB.Driver;

namespace EnglishLearning.Multimedia.Persistence.Repositories.Audio
{
    public class EnglishAudioFilterRepository : IEnglishAudioFiltersRepository
    {
        protected readonly MongoContext _dbContext;
        protected readonly IMongoCollection<EnglishAudio> _collection;

        public EnglishAudioFilterRepository(MongoContext dbContext)
        {
            _dbContext = dbContext;
            _collection = _dbContext.GetCollection<EnglishAudio>();
        }

        public AudioPlayerTypeFilter GetAudioPlayerTypeFilter()
        {
            var filterOptions = _collection
                .Aggregate()
                .Group(x => x.AudioPlayerType, group => new
                {
                    Key = group.Key,
                    Value = group.Count()
                })
                .ToEnumerable()
                .ToDictionary(x => x.Key, x => x.Value);

            var audioPlayerTypeFilter = new AudioPlayerTypeFilter { FilterOptions = filterOptions };
            
            return audioPlayerTypeFilter;
        }

        public AudioTypeFilter GetAudioTypeFilter()
        {
            var filterOptions = _collection
                .Aggregate()
                .Group(x => x.AudioType, group => new
                {
                    Key = group.Key,
                    Value = group.Count()
                })
                .ToEnumerable()
                .ToDictionary(x => x.Key, x => x.Value);

            var audioTypeFilter = new AudioTypeFilter { FilterOptions = filterOptions };
            
            return audioTypeFilter;
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

        public EnglishAudioFullFilter GetEnglishAudioFullFilter()
        {
            var englishAudioFullFilter = new EnglishAudioFullFilter()
            {
                EnglishLevelFilterOptions = GetEnglishLevelFilter(),
                AudioTypeFilterOptions = GetAudioTypeFilter(),
                AudioPlayerFilterOptions = GetAudioPlayerTypeFilter()
            };
            
            return englishAudioFullFilter;
        }
    }
}
