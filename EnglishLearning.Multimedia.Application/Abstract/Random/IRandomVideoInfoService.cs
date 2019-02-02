using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Multimedia.Application.Models.Enums;
using EnglishLearning.Multimedia.Application.Models.InfoModels;

namespace EnglishLearning.Multimedia.Application.Abstract.Random
{
    public interface IRandomVideoInfoService
    {
        Task<EnglishVideoInfoModel> GetRandomInfoFromAllAsync();
        Task<EnglishVideoInfoModel> FindRandomInfoByPhraseAsync(int amount, string phrase);
        Task<EnglishVideoInfoModel> FindRandomInfoByFiltersAsync(int amount, string[] videoTypes, EnglishLevelModel[] englishLevels);
        Task<EnglishVideoInfoModel> FindRandomInfoByFiltersAsync(int amount, string phrase, string[] videoTypes, EnglishLevelModel[] englishLevels);

        Task<IReadOnlyList<EnglishVideoInfoModel>> GetRandomAmountInfoFromAllAsync(int amount);
        Task<IReadOnlyList<EnglishVideoInfoModel>> FindRandomAmountInfoByPhraseAsync(int amount, string phrase);
        Task<IReadOnlyList<EnglishVideoInfoModel>> FindRandomAmountInfoByFiltersAsync(int amount, string[] videoTypes, EnglishLevelModel[] englishLevels);
        Task<IReadOnlyList<EnglishVideoInfoModel>> FindRandomAmountInfoByFiltersAsync(int amount, string phrase, string[] videoTypes, EnglishLevelModel[] englishLevels);
    }
}