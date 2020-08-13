using EnglishLearning.Multimedia.Web.ViewModels.Enums;

namespace EnglishLearning.Multimedia.Web.ViewModels
{
    public class EnglishTextViewModel
    {
        public string Id { get; set; }
        
        public string Text { get; set; }
        public string HeadLine { get; set; }
        
        public string TextType { get; set; }
        public EnglishLevelViewModel EnglishLevel { get; set; }
    }
}