using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Multimedia.Application.Models;
using EnglishLearning.Multimedia.Application.Models.Enums;
using EnglishLearning.Multimedia.Application.Models.InfoModels;

namespace EnglishLearning.Multimedia.Application.Abstract.Random
{
    public interface IRandomAudioService
    {
        Task<EnglishAudioModel> GetRandomFromAllAsync();
        Task<EnglishAudioModel> FindRandomByPhraseAsync(int amount, string phrase);
        Task<EnglishAudioModel> FindRandomByFiltersAsync(int amount, string[] audioTypes, EnglishLevelModel[] englishLevels);
        Task<EnglishAudioModel> FindRandomByFiltersAsync(int amount, string phrase, string[] audioTypes, EnglishLevelModel[] englishLevels);
        
        Task<EnglishAudioInfoModel> GetRandomInfoFromAllAsync();
        Task<EnglishAudioInfoModel> FindRandomInfoByPhraseAsync(int amount, string phrase);
        Task<EnglishAudioInfoModel> FindRandomInfoByFiltersAsync(int amount, string[] audioTypes, EnglishLevelModel[] englishLevels);
        Task<EnglishAudioInfoModel> FindRandomInfoByFiltersAsync(int amount, string phrase, string[] audioTypes, EnglishLevelModel[] englishLevels);
        
        Task<IReadOnlyList<EnglishAudioModel>> GetRandomAmountFromAllAsync(int amount);
        Task<IReadOnlyList<EnglishAudioModel>> FindRandomAmountByPhraseAsync(int amount, string phrase);
        Task<IReadOnlyList<EnglishAudioModel>> FindRandomAmountByFiltersAsync(int amount, string[] audioTypes, EnglishLevelModel[] englishLevels);
        Task<IReadOnlyList<EnglishAudioModel>> FindRandomAmountByFiltersAsync(int amount, string phrase, string[] audioTypes, EnglishLevelModel[] englishLevels);
        
        Task<IReadOnlyList<EnglishAudioInfoModel>> GetRandomAmountInfoFromAllAsync(int amount);
        Task<IReadOnlyList<EnglishAudioInfoModel>> FindRandomAmountInfoByPhraseAsync(int amount, string phrase);
        Task<IReadOnlyList<EnglishAudioInfoModel>> FindRandomAmountInfoByFiltersAsync(int amount, string[] audioTypes, EnglishLevelModel[] englishLevels);
        Task<IReadOnlyList<EnglishAudioInfoModel>> FindRandomAmountInfoByFiltersAsync(int amount, string phrase, string[] audioTypes, EnglishLevelModel[] englishLevels);
    }
}