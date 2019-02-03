using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnglishLearning.Multimedia.Application.Abstract;
using EnglishLearning.Multimedia.Application.Abstract.Random;
using EnglishLearning.Multimedia.Application.Models;
using EnglishLearning.Multimedia.Application.Models.Enums;
using EnglishLearning.Utilities.Linq.Extensions;

namespace EnglishLearning.Multimedia.Application.Services.Random
{
    public class RandomAudioService : IRandomAudioService
    {
        private readonly IAudioService _audioService;
        
        public RandomAudioService(IAudioService audioService)
        {
            _audioService = audioService;
        }
        
        public async Task<EnglishAudioModel> GetRandomFromAllAsync()
        {
            IReadOnlyList<EnglishAudioModel> englishAudios = await _audioService.GetAllAsync();
            if (!englishAudios.Any())
                return null;
            
            return englishAudios.GetRandomElement();
        }

        public async Task<EnglishAudioModel> FindRandomByPhraseAsync(int amount, string phrase)
        {
            IReadOnlyList<EnglishAudioModel> englishAudios = await _audioService.FindAllByPhrase(phrase);
            if (!englishAudios.Any())
                return null;

            return englishAudios.GetRandomElement();
        }

        public async Task<EnglishAudioModel> FindRandomByFiltersAsync(int amount, string[] audioTypes, EnglishLevelModel[] englishLevels)
        {
            IReadOnlyList<EnglishAudioModel> englishAudios = await _audioService.FindAllByFilters(audioTypes, englishLevels);
            if (!englishAudios.Any())
                return null;

            return englishAudios.GetRandomElement();
        }

        public async Task<EnglishAudioModel> FindRandomByFiltersAsync(int amount, string phrase, string[] audioTypes, EnglishLevelModel[] englishLevels)
        {
            IReadOnlyList<EnglishAudioModel> englishAudios = await _audioService.FindAllByFilters(phrase, audioTypes, englishLevels);
            if (!englishAudios.Any())
                return null;

            return englishAudios.GetRandomElement();
        }

        public async Task<IReadOnlyList<EnglishAudioModel>> GetRandomAmountFromAllAsync(int amount)
        {
            IReadOnlyList<EnglishAudioModel> englishAudios = await _audioService.GetAllAsync();
            if (!englishAudios.Any())
                return englishAudios;
            
            return englishAudios.GetRandomCountOfElements(amount).ToList();
        }

        public async Task<IReadOnlyList<EnglishAudioModel>> FindRandomAmountByPhraseAsync(int amount, string phrase)
        {
            IReadOnlyList<EnglishAudioModel> englishAudios = await _audioService.FindAllByPhrase(phrase);
            if (!englishAudios.Any())
                return englishAudios;

            return englishAudios.GetRandomCountOfElements(amount).ToList();
        }

        public async Task<IReadOnlyList<EnglishAudioModel>> FindRandomAmountByFiltersAsync(int amount, string[] audioTypes, EnglishLevelModel[] englishLevels)
        {
            IReadOnlyList<EnglishAudioModel> englishAudios = await _audioService.FindAllByFilters(audioTypes, englishLevels);
            if (!englishAudios.Any())
                return englishAudios;

            return englishAudios.GetRandomCountOfElements(amount).ToList();
        }

        public async Task<IReadOnlyList<EnglishAudioModel>> FindRandomAmountByFiltersAsync(int amount, string phrase, string[] audioTypes, EnglishLevelModel[] englishLevels)
        {
            IReadOnlyList<EnglishAudioModel> englishAudios = await _audioService.FindAllByFilters(phrase, audioTypes, englishLevels);
            if (!englishAudios.Any())
                return englishAudios;

            return englishAudios.GetRandomCountOfElements(amount).ToList();
        }
    }
}
