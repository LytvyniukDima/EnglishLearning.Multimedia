using EnglishLearning.Utilities.Persistence.Mongo.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EnglishLearning.Multimedia.Persistence.Entities.Video
{
    public class EnglishVideo : IStringIdEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public string ApiId { get; set; }
        public string Title { get; set; }
        public string Transcription { get; set; }
        
        public string VideoType { get; set; }
        [BsonRepresentation(BsonType.String)]
        public EnglishLevel EnglishLevel { get; set; }
    }
}
