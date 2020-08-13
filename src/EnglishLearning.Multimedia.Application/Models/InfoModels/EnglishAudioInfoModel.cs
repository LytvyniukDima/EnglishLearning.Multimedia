using System;
using EnglishLearning.Multimedia.Application.Models.Enums;

namespace EnglishLearning.Multimedia.Application.Models.InfoModels
{
    public class EnglishAudioInfoModel
    {
        public string Id { get; set; }
        
        public string Tittle { get; set; }
        public TimeSpan Duration { get; set; }
        
        public string AudioType { get; set; }
        public EnglishLevelModel EnglishLevel { get; set; }
        public AudioPlayerTypeModel AudioPlayerType { get; set; }
    }
}
