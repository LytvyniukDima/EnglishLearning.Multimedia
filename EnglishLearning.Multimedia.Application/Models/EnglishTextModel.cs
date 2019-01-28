using EnglishLearning.Multimedia.Application.Models.Enums;

namespace EnglishLearning.Multimedia.Application.Models
{
    public class EnglishTextModel
    {
        public string Id { get; set; }
        
        public string Text { get; set; }
        public string HeadLine { get; set; }
        
        public string TextType { get; set; }
        public EnglishLevelModel EnglishLevel { get; set; }
    }
}