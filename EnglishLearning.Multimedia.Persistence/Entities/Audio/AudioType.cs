using EnglishLearning.Multimedia.Persistence.Abstract;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EnglishLearning.Multimedia.Persistence.Entities.Audio
{
    public class AudioType : IEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public string TypeOfAudio { get; set; }
        
        public int Count { get; set; }
    }
}