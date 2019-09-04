using System;
using System.ComponentModel.DataAnnotations;
using EnglishLearning.Multimedia.Web.ViewModels.Enums;

namespace EnglishLearning.Multimedia.Web.ViewModels.Create
{
    public class EnglishAudioCreateViewModel
    {
        [Required]
        public string ApiId { get; set; }
        [Required]
        public string Tittle { get; set; }
        public TimeSpan Duration { get; set; }
        [Required]
        public Uri Uri { get; set; }
        [Required]
        public string Transcription { get; set; }
        
        [Required]
        public string AudioType { get; set; } 
        [Required]
        public EnglishLevelViewModel EnglishLevel { get; set; }
        [Required]
        public AudioPlayerTypeViewModel AudioPlayerType { get; set; }
    }
}