using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EnglishLearning.Multimedia.Persistence.Abstract
{
    public interface IEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        string Id { get; set; }
    }
}