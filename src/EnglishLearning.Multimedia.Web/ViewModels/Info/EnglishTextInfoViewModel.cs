using EnglishLearning.Multimedia.Web.ViewModels.Enums;

namespace EnglishLearning.Multimedia.Web.ViewModels.Info
{
    public class EnglishTextInfoViewModel
    {
        public string Id { get; set; }
        
        public string HeadLine { get; set; }
        
        public string TextType { get; set; }
        public EnglishLevelViewModel EnglishLevel { get; set; }
    }
}