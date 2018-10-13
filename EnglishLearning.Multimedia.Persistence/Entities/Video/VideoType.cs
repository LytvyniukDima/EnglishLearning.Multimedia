using EnglishLearning.Multimedia.Persistence.Abstract;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EnglishLearning.Multimedia.Persistence.Entities.Video
{
    public class VideoType : IEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public string TypeOfVideo { get; set; }
        
        public int Count { get; set; }
    }
}