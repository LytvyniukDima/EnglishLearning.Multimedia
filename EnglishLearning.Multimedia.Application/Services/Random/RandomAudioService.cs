using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Multimedia.Application.Abstract.Random;
using EnglishLearning.Multimedia.Application.Models;
using EnglishLearning.Multimedia.Application.Models.Enums;

namespace EnglishLearning.Multimedia.Application.Services.Random
{
    public class RandomAudioService : IRandomAudioService
    {
        public async Task<EnglishAudioModel> GetRandomFromAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<EnglishAudioModel> FindRandomByPhraseAsync(int amount, string phrase)
        {
            throw new System.NotImplementedException();
        }

        public async Task<EnglishAudioModel> FindRandomByFiltersAsync(int amount, string[] audioTypes, EnglishLevelModel[] englishLevels)
        {
            throw new System.NotImplementedException();
        }

        public async Task<EnglishAudioModel> FindRandomByFiltersAsync(int amount, string phrase, string[] audioTypes, EnglishLevelModel[] englishLevels)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<EnglishAudioModel>> GetRandomAmountFromAllAsync(int amount)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<EnglishAudioModel>> FindRandomAmountByPhraseAsync(int amount, string phrase)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<EnglishAudioModel>> FindRandomAmountByFiltersAsync(int amount, string[] audioTypes, EnglishLevelModel[] englishLevels)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<EnglishAudioModel>> FindRandomAmountByFiltersAsync(int amount, string phrase, string[] audioTypes, EnglishLevelModel[] englishLevels)
        {
            throw new System.NotImplementedException();
        }
    }
}