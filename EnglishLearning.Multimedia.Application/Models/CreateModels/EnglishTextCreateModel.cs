using EnglishLearning.Multimedia.Application.Models.Enums;

namespace EnglishLearning.Multimedia.Application.Models.CreateModels
{
    public class EnglishTextCreateModel
    {
        public string Text { get; set; }
        public string HeadLine { get; set; }
        
        public string TextType { get; set; }
        public EnglishLevelModel EnglishLevel { get; set; }
    }
}