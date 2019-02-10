using EnglishLearning.Multimedia.Web.ViewModels.Enums;

namespace EnglishLearning.Multimedia.Web.ViewModels.Create
{
    public class EnglishVideoCreateViewModel
    {
        public string ApiId { get; set; }
        public string Title { get; set; }
        public string Transcription { get; set; }
        
        public string VideoType { get; set; }
        public EnglishLevelViewModel EnglishLevel { get; set; }
    }
}