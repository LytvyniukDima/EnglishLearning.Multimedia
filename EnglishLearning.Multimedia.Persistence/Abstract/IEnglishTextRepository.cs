using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Multimedia.Persistence.Entities;
using EnglishLearning.Multimedia.Persistence.Entities.Text;
using EnglishLearning.Utilities.Persistence.Interfaces;

namespace EnglishLearning.Multimedia.Persistence.Abstract
{
    public interface IEnglishTextRepository : IBaseWithInfoModelRepository<EnglishText, EnglishTextInfo>
    {
        Task<IReadOnlyList<EnglishText>> FindAllByPhrase(string phrase);
        Task<IReadOnlyList<EnglishText>> FindAllByFilters(string[] textTypes, EnglishLevel[] englishLevels);
        Task<IReadOnlyList<EnglishText>> FindAllByFilters(string phrase, string[] textTypes, EnglishLevel[] englishLevels);
        Task<IReadOnlyList<EnglishTextInfo>> FindAllInfoByPhrase(string phrase);
        Task<IReadOnlyList<EnglishTextInfo>> FindAllInfoByFilters(string[] textTypes, EnglishLevel[] englishLevels);
        Task<IReadOnlyList<EnglishTextInfo>> FindAllInfoByFilters(string phrase, string[] textTypes, EnglishLevel[] englishLevels);
    }
}
