using EnglishLearning.Multimedia.Web.ViewModels.Enums;

namespace EnglishLearning.Multimedia.Web.ViewModels.Create
{
    public class EnglishTextCreateViewModel
    {
        public string Text { get; set; }
        public string HeadLine { get; set; }
        
        public string TextType { get; set; }
        public EnglishLevelViewModel EnglishLevel { get; set; }
    }
}