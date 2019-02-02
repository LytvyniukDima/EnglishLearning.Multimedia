using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Multimedia.Application.Abstract.Random;
using EnglishLearning.Multimedia.Application.Models.Enums;
using EnglishLearning.Multimedia.Application.Models.InfoModels;

namespace EnglishLearning.Multimedia.Application.Services.Random
{
    public class RandomTextInfoService : IRandomTextInfoService
    {
        public async Task<EnglishTextInfoModel> GetRandomInfoFromAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<EnglishTextInfoModel> FindRandomInfoByPhraseAsync(int amount, string phrase)
        {
            throw new System.NotImplementedException();
        }

        public async Task<EnglishTextInfoModel> FindRandomInfoByFiltersAsync(int amount, string[] textTypes, EnglishLevelModel[] englishLevels)
        {
            throw new System.NotImplementedException();
        }

        public async Task<EnglishTextInfoModel> FindRandomInfoByFiltersAsync(int amount, string phrase, string[] textTypes, EnglishLevelModel[] englishLevels)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<EnglishTextInfoModel>> GetRandomAmountInfoFromAllAsync(int amount)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<EnglishTextInfoModel>> FindRandomAmountInfoByPhraseAsync(int amount, string phrase)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<EnglishTextInfoModel>> FindRandomAmountInfoByFiltersAsync(int amount, string[] textTypes, EnglishLevelModel[] englishLevels)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<EnglishTextInfoModel>> FindRandomAmountInfoByFiltersAsync(int amount, string phrase, string[] textTypes,
            EnglishLevelModel[] englishLevels)
        {
            throw new System.NotImplementedException();
        }
    }
}