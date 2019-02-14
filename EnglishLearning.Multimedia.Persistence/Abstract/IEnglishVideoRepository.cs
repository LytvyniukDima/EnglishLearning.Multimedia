using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Multimedia.Persistence.Entities;
using EnglishLearning.Multimedia.Persistence.Entities.Video;
using EnglishLearning.Utilities.Persistence.Interfaces;

namespace EnglishLearning.Multimedia.Persistence.Abstract
{
    public interface IEnglishVideoRepository : IBaseWithInfoModelRepository<EnglishVideo, EnglishVideoInfo>
    {
        Task<IReadOnlyList<EnglishVideo>> FindAllByFilters(string phrase, string[] videoTypes, EnglishLevel[] englishLevels);
        Task<IReadOnlyList<EnglishVideoInfo>> FindAllInfoByFilters(string phrase, string[] videoTypes, EnglishLevel[] englishLevels);
    }
}
