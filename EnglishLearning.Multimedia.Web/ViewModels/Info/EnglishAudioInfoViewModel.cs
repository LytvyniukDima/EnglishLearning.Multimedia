using System;
using EnglishLearning.Multimedia.Web.ViewModels.Enums;

namespace EnglishLearning.Multimedia.Web.ViewModels.Info
{
    public class EnglishAudioInfoViewModel
    {
        public string Id { get; set; }
        
        public string Tittle { get; set; }
        public TimeSpan Duration { get; set; }
        
        public string AudioType { get; set; }
        public EnglishLevelViewModel EnglishLevel { get; set; }
        public AudioPlayerTypeViewModel AudioPlayerType { get; set; }
    }
}