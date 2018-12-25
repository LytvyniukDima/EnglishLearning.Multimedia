using EnglishLearning.Multimedia.Persistence.Abstract;
using EnglishLearning.Multimedia.Persistence.Configuration;
using EnglishLearning.Utilities.Configurations.MongoConfiguration;
using EnglishLearning.Utilities.Persistence.Mongo.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EnglishLearning.Multimedia.Persistence.Contexts
{
    public class MultimediaDbContext : IMongoContext
    {
        private readonly IMongoDatabase _database;
        private readonly MongoConfiguration _mongoDbConfiguration;

        public MultimediaDbContext(IOptions<MongoConfiguration> mongoConfiguration)
        {
            _mongoDbConfiguration = mongoConfiguration.Value;
            
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