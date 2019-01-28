using System;
using EnglishLearning.Multimedia.Application.Models.Enums;

namespace EnglishLearning.Multimedia.Application.Models.CreateModels
{
    public class EnglishAudioCreateModel
    {
        public string ApiId { get; set; }
        public string Tittle { get; set; }
        public int Duration { get; set; }
        public Uri Uri { get; set; }
        public string Transcription { get; set; }
        
        public string AudioType { get; set; } 
        public EnglishLevelModel EnglishLevel { get; set; }
        public AudioPlayerTypeModel AudioPlayerType { get; set; }
    }
}