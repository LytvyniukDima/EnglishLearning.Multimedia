using System;
using EnglishLearning.Multimedia.Web.ViewModels.Enums;

namespace EnglishLearning.Multimedia.Web.ViewModels.Create
{
    public class EnglishAudioCreateViewModel
    {
        public string ApiId { get; set; }
        public string Tittle { get; set; }
        public int Duration { get; set; }
        public Uri Uri { get; set; }
        public string Transcription { get; set; }
        
        public string AudioType { get; set; } 
        public EnglishLevelViewModel EnglishLevel { get; set; }
        public AudioPlayerTypeViewModel AudioPlayerType { get; set; }
    }
}