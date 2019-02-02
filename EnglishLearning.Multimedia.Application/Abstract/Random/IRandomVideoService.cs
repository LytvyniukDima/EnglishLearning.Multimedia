using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Multimedia.Application.Models;
using EnglishLearning.Multimedia.Application.Models.Enums;

namespace EnglishLearning.Multimedia.Application.Abstract.Random
{
    public interface IRandomVideoService
    {
        Task<EnglishVideoModel> GetRandomFromAllAsync();
        Task<EnglishVideoModel> FindRandomByPhraseAsync(int amount, string phrase);
        Task<EnglishVideoModel> FindRandomByFiltersAsync(int amount, string[] videoTypes, EnglishLevelModel[] englishLevels);
        Task<EnglishVideoModel> FindRandomByFiltersAsync(int amount, string phrase, string[] videoTypes, EnglishLevelModel[] englishLevels);
        
        Task<IReadOnlyList<EnglishVideoModel>> GetRandomAmountFromAllAsync(int amount);
        Task<IReadOnlyList<EnglishVideoModel>> FindRandomAmountByPhraseAsync(int amount, string phrase);
        Task<IReadOnlyList<EnglishVideoModel>> FindRandomAmountByFiltersAsync(int amount, string[] videoTypes, EnglishLevelModel[] englishLevels);
        Task<IReadOnlyList<EnglishVideoModel>> FindRandomAmountByFiltersAsync(int amount, string phrase, string[] videoTypes, EnglishLevelModel[] englishLevels);
    }
}
