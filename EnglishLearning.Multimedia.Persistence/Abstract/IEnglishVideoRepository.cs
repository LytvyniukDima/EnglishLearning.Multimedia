using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Multimedia.Persistence.Entities;
using EnglishLearning.Multimedia.Persistence.Entities.Video;
using EnglishLearning.Utilities.Persistence.Interfaces;

namespace EnglishLearning.Multimedia.Persistence.Abstract
{
    public interface IEnglishVideoRepository : IBaseWithInfoModelRepository<EnglishVideo, EnglishVideoInfo>
    {
        Task<IReadOnlyList<EnglishVideo>> FindAllByPhrase(string phrase);
        Task<IReadOnlyList<EnglishVideo>> FindAllByFilters(string[] videoTypes, EnglishLevel[] englishLevels);
        Task<IReadOnlyList<EnglishVideoInfo>> FindAllInfoByPhrase(string phrase);
        Task<IReadOnlyList<EnglishVideoInfo>> FindAllInfoByFilters(string[] videoTypes, EnglishLevel[] englishLevels);
    }
}
