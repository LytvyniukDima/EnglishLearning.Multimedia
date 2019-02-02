using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Multimedia.Application.Abstract.Random;
using EnglishLearning.Multimedia.Application.Models;
using EnglishLearning.Multimedia.Application.Models.Enums;

namespace EnglishLearning.Multimedia.Application.Services.Random
{
    public class RandomVideoService : IRandomVideoService
    {
        public async Task<EnglishVideoModel> GetRandomFromAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<EnglishVideoModel> FindRandomByPhraseAsync(int amount, string phrase)
        {
            throw new System.NotImplementedException();
        }

        public async Task<EnglishVideoModel> FindRandomByFiltersAsync(int amount, string[] videoTypes, EnglishLevelModel[] englishLevels)
        {
            throw new System.NotImplementedException();
        }

        public async Task<EnglishVideoModel> FindRandomByFiltersAsync(int amount, string phrase, string[] videoTypes, EnglishLevelModel[] englishLevels)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<EnglishVideoModel>> GetRandomAmountFromAllAsync(int amount)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<EnglishVideoModel>> FindRandomAmountByPhraseAsync(int amount, string phrase)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<EnglishVideoModel>> FindRandomAmountByFiltersAsync(int amount, string[] videoTypes, EnglishLevelModel[] englishLevels)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<EnglishVideoModel>> FindRandomAmountByFiltersAsync(int amount, string phrase, string[] videoTypes, EnglishLevelModel[] englishLevels)
        {
            throw new System.NotImplementedException();
        }
    }
}