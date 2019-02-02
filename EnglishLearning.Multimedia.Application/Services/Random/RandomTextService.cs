using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Multimedia.Application.Abstract.Random;
using EnglishLearning.Multimedia.Application.Models;
using EnglishLearning.Multimedia.Application.Models.Enums;

namespace EnglishLearning.Multimedia.Application.Services.Random
{
    public class RandomTextService : IRandomTextService
    {
        public async Task<EnglishTextModel> GetRandomFromAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<EnglishTextModel> FindRandomByPhraseAsync(int amount, string phrase)
        {
            throw new System.NotImplementedException();
        }

        public async Task<EnglishTextModel> FindRandomByFiltersAsync(int amount, string[] textTypes, EnglishLevelModel[] englishLevels)
        {
            throw new System.NotImplementedException();
        }

        public async Task<EnglishTextModel> FindRandomByFiltersAsync(int amount, string phrase, string[] textTypes, EnglishLevelModel[] englishLevels)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<EnglishTextModel>> GetRandomAmountFromAllAsync(int amount)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<EnglishTextModel>> FindRandomAmountByPhraseAsync(int amount, string phrase)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<EnglishTextModel>> FindRandomAmountByFiltersAsync(int amount, string[] textTypes, EnglishLevelModel[] englishLevels)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<EnglishTextModel>> FindRandomAmountByFiltersAsync(int amount, string phrase, string[] textTypes, EnglishLevelModel[] englishLevels)
        {
            throw new System.NotImplementedException();
        }
    }
}