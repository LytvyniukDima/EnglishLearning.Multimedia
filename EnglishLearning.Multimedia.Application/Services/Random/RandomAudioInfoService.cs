using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Multimedia.Application.Abstract.Random;
using EnglishLearning.Multimedia.Application.Models.Enums;
using EnglishLearning.Multimedia.Application.Models.InfoModels;

namespace EnglishLearning.Multimedia.Application.Services.Random
{
    public class RandomAudioInfoService : IRandomAudioInfoService
    {
        public async Task<EnglishAudioInfoModel> GetRandomInfoFromAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<EnglishAudioInfoModel> FindRandomInfoByPhraseAsync(int amount, string phrase)
        {
            throw new System.NotImplementedException();
        }

        public async Task<EnglishAudioInfoModel> FindRandomInfoByFiltersAsync(int amount, string[] audioTypes, EnglishLevelModel[] englishLevels)
        {
            throw new System.NotImplementedException();
        }

        public async Task<EnglishAudioInfoModel> FindRandomInfoByFiltersAsync(int amount, string phrase, string[] audioTypes, EnglishLevelModel[] englishLevels)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<EnglishAudioInfoModel>> GetRandomAmountInfoFromAllAsync(int amount)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<EnglishAudioInfoModel>> FindRandomAmountInfoByPhraseAsync(int amount, string phrase)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<EnglishAudioInfoModel>> FindRandomAmountInfoByFiltersAsync(int amount, string[] audioTypes, EnglishLevelModel[] englishLevels)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<EnglishAudioInfoModel>> FindRandomAmountInfoByFiltersAsync(int amount, string phrase, string[] audioTypes,
            EnglishLevelModel[] englishLevels)
        {
            throw new System.NotImplementedException();
        }
    }
}