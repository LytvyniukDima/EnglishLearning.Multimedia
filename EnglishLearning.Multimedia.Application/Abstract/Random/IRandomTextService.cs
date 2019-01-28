using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Multimedia.Application.Models;
using EnglishLearning.Multimedia.Application.Models.Enums;
using EnglishLearning.Multimedia.Application.Models.InfoModels;

namespace EnglishLearning.Multimedia.Application.Abstract.Random
{
    public interface IRandomTextService
    {
        Task<EnglishTextModel> GetRandomFromAllAsync();
        Task<EnglishTextModel> FindRandomByPhraseAsync(int amount, string phrase);
        Task<EnglishTextModel> FindRandomByFiltersAsync(int amount, string[] textTypes, EnglishLevelModel[] englishLevels);
        Task<EnglishTextModel> FindRandomByFiltersAsync(int amount, string phrase, string[] textTypes, EnglishLevelModel[] englishLevels);
        
        Task<EnglishTextInfoModel> GetRandomInfoFromAllAsync();
        Task<EnglishTextInfoModel> FindRandomInfoByPhraseAsync(int amount, string phrase);
        Task<EnglishTextInfoModel> FindRandomInfoByFiltersAsync(int amount, string[] textTypes, EnglishLevelModel[] englishLevels);
        Task<EnglishTextInfoModel> FindRandomInfoByFiltersAsync(int amount, string phrase, string[] textTypes, EnglishLevelModel[] englishLevels);
        
        Task<IReadOnlyList<EnglishTextModel>> GetRandomAmountFromAllAsync(int amount);
        Task<IReadOnlyList<EnglishTextModel>> FindRandomAmountByPhraseAsync(int amount, string phrase);
        Task<IReadOnlyList<EnglishTextModel>> FindRandomAmountByFiltersAsync(int amount, string[] textTypes, EnglishLevelModel[] englishLevels);
        Task<IReadOnlyList<EnglishTextModel>> FindRandomAmountByFiltersAsync(int amount, string phrase, string[] textTypes, EnglishLevelModel[] englishLevels);
        
        Task<IReadOnlyList<EnglishTextInfoModel>> GetRandomAmountInfoFromAllAsync(int amount);
        Task<IReadOnlyList<EnglishTextInfoModel>> FindRandomAmountInfoByPhraseAsync(int amount, string phrase);
        Task<IReadOnlyList<EnglishTextInfoModel>> FindRandomAmountInfoByFiltersAsync(int amount, string[] textTypes, EnglishLevelModel[] englishLevels);
        Task<IReadOnlyList<EnglishTextInfoModel>> FindRandomAmountInfoByFiltersAsync(int amount, string phrase, string[] textTypes, EnglishLevelModel[] englishLevels);
    }
}