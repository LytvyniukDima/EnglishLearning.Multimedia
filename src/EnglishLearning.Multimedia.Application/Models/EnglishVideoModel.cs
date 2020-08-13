using EnglishLearning.Multimedia.Application.Models.Enums;

namespace EnglishLearning.Multimedia.Application.Models
{
    public class EnglishVideoModel
    {
        public string Id { get; set; }
        
        public string ApiId { get; set; }
        public string Title { get; set; }
        public string Transcription { get; set; }
        
        public string VideoType { get; set; }
        public EnglishLevelModel EnglishLevel { get; set; }
    }
}