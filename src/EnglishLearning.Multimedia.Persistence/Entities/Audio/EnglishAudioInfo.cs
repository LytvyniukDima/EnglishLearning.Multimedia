using System;
using EnglishLearning.Utilities.Persistence.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EnglishLearning.Multimedia.Persistence.Entities.Audio
{
    public class EnglishAudioInfo : IEntity<string>
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public string Tittle { get; set; }
        public TimeSpan Duration { get; set; }
        
        public string AudioType { get; set; }
        [BsonRepresentation(BsonType.String)]
        public EnglishLevel EnglishLevel { get; set; }
        [BsonRepresentation(BsonType.String)]
        public AudioPlayerType AudioPlayerType { get; set; }
    }
}
