using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Multimedia.Persistence.Entities;
using EnglishLearning.Multimedia.Persistence.Entities.Audio;
using EnglishLearning.Utilities.Persistence.Interfaces;

namespace EnglishLearning.Multimedia.Persistence.Abstract
{
    public interface IEnglishAudioRepository : IBaseWithInfoModelRepository<EnglishAudio, EnglishAudioInfo, string>
    {
        Task<IReadOnlyList<EnglishAudio>> FindAllByFilters(string phrase, string[] audioTypes, EnglishLevel[] englishLevels);
        Task<IReadOnlyList<EnglishAudioInfo>> FindAllInfoByFilters(string phrase, string[] audioTypes, EnglishLevel[] englishLevels);
    }
}
