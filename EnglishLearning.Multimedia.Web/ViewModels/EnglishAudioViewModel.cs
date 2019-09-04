using System;
using EnglishLearning.Multimedia.Web.ViewModels.Enums;

namespace EnglishLearning.Multimedia.Web.ViewModels
{
    public class EnglishAudioViewModel
    {
        public string Id { get; set; }
        
        public string ApiId { get; set; }
        public string Tittle { get; set; }
        public TimeSpan Duration { get; set; }
        public Uri Uri { get; set; }
        public string Transcription { get; set; }
        
        public string AudioType { get; set; } 
        public EnglishLevelViewModel EnglishLevel { get; set; }
        public AudioPlayerTypeViewModel AudioPlayerType { get; set; }
    }
}