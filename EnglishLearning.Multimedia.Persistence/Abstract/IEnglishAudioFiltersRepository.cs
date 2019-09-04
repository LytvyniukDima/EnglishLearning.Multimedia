using EnglishLearning.Multimedia.Persistence.Entities;
using EnglishLearning.Multimedia.Persistence.Entities.Audio;

namespace EnglishLearning.Multimedia.Persistence.Abstract
{
    public interface IEnglishAudioFiltersRepository
    {
        AudioPlayerTypeFilter GetAudioPlayerTypeFilter();
        AudioTypeFilter GetAudioTypeFilter();
        EnglishLevelFilter GetEnglishLevelFilter();
        EnglishAudioFullFilter GetEnglishAudioFullFilter();
    }
}