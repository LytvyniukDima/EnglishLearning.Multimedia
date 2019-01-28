namespace EnglishLearning.Multimedia.Application.Models.Filters
{
    public class EnglishAudioFullFilterModel
    {
        public AudioPlayerTypeFilterModel AudioPlayerFilterOptions { get; set; }
        public AudioPlayerTypeFilterModel AudioTypeFilterOptions { get; set; }
        public EnglishLevelFilterModel EnglishLevelFilterOptions { get; set; }
    }
}