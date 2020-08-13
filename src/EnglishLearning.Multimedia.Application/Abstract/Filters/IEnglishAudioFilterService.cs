using EnglishLearning.Multimedia.Application.Models.Filters;

namespace EnglishLearning.Multimedia.Application.Abstract.Filters
{
    public interface IEnglishAudioFilterService
    {
        AudioPlayerTypeFilterModel GetAudioPlayerTypeFilter();
        AudioTypeFilterModel GetAudioTypeFilter();
        EnglishLevelFilterModel GetEnglishLevelFilter();
        EnglishAudioFullFilterModel GetEnglishAudioFullFilter();
    }
}