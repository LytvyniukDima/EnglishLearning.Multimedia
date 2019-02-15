using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Multimedia.Application.Models;
using EnglishLearning.Multimedia.Application.Models.Enums;

namespace EnglishLearning.Multimedia.Application.Abstract.Random
{
    public interface IRandomAudioService
    {
        Task<EnglishAudioModel> GetRandomFromAllAsync();
        Task<EnglishAudioModel> FindRandomByFiltersAsync(string phrase, string[] audioTypes, EnglishLevelModel[] englishLevels);
        
        Task<IReadOnlyList<EnglishAudioModel>> GetRandomAmountFromAllAsync(int amount);
        Task<IReadOnlyList<EnglishAudioModel>> FindRandomAmountByFiltersAsync(int amount, string phrase, string[] audioTypes, EnglishLevelModel[] englishLevels);
    }
}