using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnglishLearning.Multimedia.Application.Abstract;
using EnglishLearning.Multimedia.Application.Abstract.Random;
using EnglishLearning.Multimedia.Application.Models.Enums;
using EnglishLearning.Multimedia.Application.Models.InfoModels;
using EnglishLearning.Utilities.Linq.Extensions;

namespace EnglishLearning.Multimedia.Application.Services.Random
{
    public class RandomAudioInfoService : IRandomAudioInfoService
    {
        private readonly IAudioService _audioService;

        public RandomAudioInfoService(IAudioService audioService)
        {
            _audioService = audioService;
        }
        
        public async Task<EnglishAudioInfoModel> GetRandomInfoFromAllAsync()
        {
            IReadOnlyList<EnglishAudioInfoModel> englishAudios = await _audioService.GetInfoAllAsync();
            if (!englishAudios.Any())
                return null;

            return englishAudios.GetRandomElement();
        }

        public async Task<EnglishAudioInfoModel> FindRandomInfoByFiltersAsync(string phrase, string[] audioTypes, EnglishLevelModel[] englishLevels)
        {
            IReadOnlyList<EnglishAudioInfoModel> englishAudios = await _audioService.FindAllInfoByFilters(phrase, audioTypes, englishLevels);
            if (!englishAudios.Any())
                return null;

            return englishAudios.GetRandomElement();
        }

        public async Task<IReadOnlyList<EnglishAudioInfoModel>> GetRandomAmountInfoFromAllAsync(int amount)
        {
            IReadOnlyList<EnglishAudioInfoModel> englishAudios = await _audioService.GetInfoAllAsync();
            if (!englishAudios.Any())
                return englishAudios;

            return englishAudios.GetRandomCountOfElements(amount).ToList();
        }

        public async Task<IReadOnlyList<EnglishAudioInfoModel>> FindRandomAmountInfoByFiltersAsync(int amount, string phrase, string[] audioTypes,
            EnglishLevelModel[] englishLevels)
        {
            IReadOnlyList<EnglishAudioInfoModel> englishAudios = await _audioService.FindAllInfoByFilters(phrase, audioTypes, englishLevels);
            if (!englishAudios.Any())
                return englishAudios;

            return englishAudios.GetRandomCountOfElements(amount).ToList();
        }
    }
}