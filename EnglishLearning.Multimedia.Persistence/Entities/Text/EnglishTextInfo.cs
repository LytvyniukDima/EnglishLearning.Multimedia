using EnglishLearning.Utilities.Persistence.Mongo.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EnglishLearning.Multimedia.Persistence.Entities.Text
{
    public class EnglishTextInfo : IStringIdEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public string HeadLine { get; set; }
        
        public string TextType { get; set; }
        public EnglishLevel EnglishLevel { get; set; }
    }
}
