using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Multimedia.Application.Models.Enums;
using EnglishLearning.Multimedia.Application.Models.InfoModels;

namespace EnglishLearning.Multimedia.Application.Abstract.Random
{
    public interface IRandomAudioInfoService
    {
        Task<EnglishAudioInfoModel> GetRandomInfoFromAllAsync();
        Task<EnglishAudioInfoModel> FindRandomInfoByFiltersAsync(string phrase, string[] audioTypes, EnglishLevelModel[] englishLevels);

        Task<IReadOnlyList<EnglishAudioInfoModel>> GetRandomAmountInfoFromAllAsync(int amount);
        Task<IReadOnlyList<EnglishAudioInfoModel>> FindRandomAmountInfoByFiltersAsync(int amount, string phrase, string[] audioTypes, EnglishLevelModel[] englishLevels);
    }
}