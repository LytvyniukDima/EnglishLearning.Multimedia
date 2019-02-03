using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Multimedia.Application.Models.Enums;
using EnglishLearning.Multimedia.Application.Models.InfoModels;

namespace EnglishLearning.Multimedia.Application.Abstract.Random
{
    public interface IRandomTextInfoService
    {
        Task<EnglishTextInfoModel> GetRandomInfoFromAllAsync();
        Task<EnglishTextInfoModel> FindRandomInfoByPhraseAsync(string phrase);
        Task<EnglishTextInfoModel> FindRandomInfoByFiltersAsync(string[] textTypes, EnglishLevelModel[] englishLevels);
        Task<EnglishTextInfoModel> FindRandomInfoByFiltersAsync(string phrase, string[] textTypes, EnglishLevelModel[] englishLevels);

        Task<IReadOnlyList<EnglishTextInfoModel>> GetRandomAmountInfoFromAllAsync(int amount);
        Task<IReadOnlyList<EnglishTextInfoModel>> FindRandomAmountInfoByPhraseAsync(int amount, string phrase);
        Task<IReadOnlyList<EnglishTextInfoModel>> FindRandomAmountInfoByFiltersAsync(int amount, string[] textTypes, EnglishLevelModel[] englishLevels);
        Task<IReadOnlyList<EnglishTextInfoModel>> FindRandomAmountInfoByFiltersAsync(int amount, string phrase, string[] textTypes, EnglishLevelModel[] englishLevels);
    }
}