using EnglishLearning.Multimedia.Web.ViewModels.Enums;

namespace EnglishLearning.Multimedia.Web.ViewModels.Info
{
    public class EnglishVideoInfoViewModel
    {
        public string Id { get; set; }
        
        public string Title { get; set; }
        
        public string VideoType { get; set; }
        public EnglishLevelViewModel EnglishLevel { get; set; }
    }
}