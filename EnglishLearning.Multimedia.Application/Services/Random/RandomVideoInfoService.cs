using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Multimedia.Application.Abstract.Random;
using EnglishLearning.Multimedia.Application.Models.Enums;
using EnglishLearning.Multimedia.Application.Models.InfoModels;

namespace EnglishLearning.Multimedia.Application.Services.Random
{
    public class RandomVideoInfoService : IRandomVideoInfoService
    {
        public async Task<EnglishVideoInfoModel> GetRandomInfoFromAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<EnglishVideoInfoModel> FindRandomInfoByPhraseAsync(int amount, string phrase)
        {
            throw new System.NotImplementedException();
        }

        public async Task<EnglishVideoInfoModel> FindRandomInfoByFiltersAsync(int amount, string[] videoTypes, EnglishLevelModel[] englishLevels)
        {
            throw new System.NotImplementedException();
        }

        public async Task<EnglishVideoInfoModel> FindRandomInfoByFiltersAsync(int amount, string phrase, string[] videoTypes, EnglishLevelModel[] englishLevels)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<EnglishVideoInfoModel>> GetRandomAmountInfoFromAllAsync(int amount)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<EnglishVideoInfoModel>> FindRandomAmountInfoByPhraseAsync(int amount, string phrase)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<EnglishVideoInfoModel>> FindRandomAmountInfoByFiltersAsync(int amount, string[] videoTypes, EnglishLevelModel[] englishLevels)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<EnglishVideoInfoModel>> FindRandomAmountInfoByFiltersAsync(int amount, string phrase, string[] videoTypes,
            EnglishLevelModel[] englishLevels)
        {
            throw new System.NotImplementedException();
        }
    }
}