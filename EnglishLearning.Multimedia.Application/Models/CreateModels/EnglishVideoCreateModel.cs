using EnglishLearning.Multimedia.Application.Models.Enums;

namespace EnglishLearning.Multimedia.Application.Models.CreateModels
{
    public class EnglishVideoCreateModel
    {
        public string ApiId { get; set; }
        public string Title { get; set; }
        public string Transcription { get; set; }
        
        public string VideoType { get; set; }
        public EnglishLevelModel EnglishLevel { get; set; }
    }
}