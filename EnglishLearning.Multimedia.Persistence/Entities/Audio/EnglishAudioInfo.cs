using EnglishLearning.Utilities.Persistence.Mongo.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EnglishLearning.Multimedia.Persistence.Entities.Audio
{
    public class EnglishAudioInfo : IStringIdEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public string Tittle { get; set; }
        public int Duration { get; set; }
        
        public string AudioType { get; set; }
        [BsonRepresentation(BsonType.String)]
        public EnglishLevel EnglishLevel { get; set; }
        [BsonRepresentation(BsonType.String)]
        public AudioPlayerType AudioPlayerType { get; set; }
    }
}
