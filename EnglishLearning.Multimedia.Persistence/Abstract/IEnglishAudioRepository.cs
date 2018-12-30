using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Multimedia.Persistence.Entities;
using EnglishLearning.Multimedia.Persistence.Entities.Audio;
using EnglishLearning.Utilities.Persistence.Interfaces;

namespace EnglishLearning.Multimedia.Persistence.Abstract
{
    public interface IEnglishAudioRepository : IBaseWithInfoModelRepository<EnglishAudio, EnglishAudioInfo>
    {
        Task<IReadOnlyList<EnglishAudio>> FindAllByPhrase(string phrase);
        Task<IReadOnlyList<EnglishAudio>> FindAllByFilters(string[] audioTypes, EnglishLevel[] englishLevels);
        Task<IReadOnlyList<EnglishAudioInfo>> FindAllInfoByPhrase(string phrase);
        Task<IReadOnlyList<EnglishAudioInfo>> FindAllInfoByFilters(string[] audioTypes, EnglishLevel[] englishLevels);
    }
}
