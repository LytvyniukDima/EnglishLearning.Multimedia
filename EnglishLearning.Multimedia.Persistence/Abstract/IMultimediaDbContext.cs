using MongoDB.Driver;

namespace EnglishLearning.Multimedia.Persistence.Abstract
{
    public interface IMultimediaDbContext
    {
        IMongoCollection<T> GetCollection<T>(string collectionName);
    }
}