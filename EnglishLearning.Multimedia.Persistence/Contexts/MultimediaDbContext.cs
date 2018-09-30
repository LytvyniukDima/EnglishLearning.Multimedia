using EnglishLearning.Multimedia.Persistence.Abstract;
using EnglishLearning.Multimedia.Persistence.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EnglishLearning.Multimedia.Persistence.Contexts
{
    public class MultimediaDbContext : IMultimediaDbContext
    {
        private readonly IMongoDatabase _database;
        private readonly MongoDbConfiguration _mongoDbConfiguration;

        public MultimediaDbContext(IOptions<MongoDbConfiguration> mongoDbConfiguration)
        {
            _mongoDbConfiguration = mongoDbConfiguration.Value;
            
            var client = new MongoClient(_mongoDbConfiguration.ServerAddress);
            // TODO: Throw exception
            if (client != null)
                _database = client.GetDatabase(_mongoDbConfiguration.DatabaseName);
        }
        
        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}