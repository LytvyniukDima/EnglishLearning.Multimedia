using EnglishLearning.Multimedia.Application.Models.Enums;

namespace EnglishLearning.Multimedia.Application.Models.InfoModels
{
    public class EnglishVideoInfoModel
    {
        public string Id { get; set; }
        
        public string Title { get; set; }
        
        public string VideoType { get; set; }
        public EnglishLevelModel EnglishLevel { get; set; }
    }
}