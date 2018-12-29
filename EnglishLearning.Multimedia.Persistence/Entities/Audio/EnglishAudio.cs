using System;
using EnglishLearning.Utilities.Persistence.Mongo.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EnglishLearning.Multimedia.Persistence.Entities.Audio
{
    public class EnglishAudio : IStringIdEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public string ApiId { get; set; }
        public string Tittle { get; set; }
        public int Duration { get; set; }
        public Uri Uri { get; set; }
        public string Transcription { get; set; }
        
        public string AudioType { get; set; }
        public EnglishLevel EnglishLevel { get; set; }
        public AudioPlayerType AudioPlayerType { get; set; }
    }
}
