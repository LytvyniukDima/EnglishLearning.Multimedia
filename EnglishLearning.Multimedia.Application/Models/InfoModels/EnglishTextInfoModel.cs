using EnglishLearning.Multimedia.Application.Models.Enums;

namespace EnglishLearning.Multimedia.Application.Models.InfoModels
{
    public class EnglishTextInfoModel
    {
        public string Id { get; set; }
        
        public string HeadLine { get; set; }
        
        public string TextType { get; set; }
        public EnglishLevelModel EnglishLevel { get; set; }
    }
}