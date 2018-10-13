using EnglishLearning.Multimedia.Persistence.Abstract;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EnglishLearning.Multimedia.Persistence.Entities.Video
{
    public class EnglishVideo : IEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public string ApiId { get; set; }
        public string Title { get; set; }
        public string Transcription { get; set; }
        
        public string VideoType { get; set; }
        public EnglishLevel EnglishLevel { get; set; }
    }
}