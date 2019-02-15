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
    public class RandomVideoService : IRandomVideoService
    {
        private readonly IVideoService _videoService;

        public RandomVideoService(IVideoService videoService)
        {
            _videoService = videoService;
        }
        
        public async Task<EnglishVideoModel> GetRandomFromAllAsync()
        {
            IReadOnlyList<EnglishVideoModel> englishVideos = await _videoService.GetAllAsync();
            if (!englishVideos.Any())
                return null;

            return englishVideos.GetRandomElement();
        }

        public async Task<EnglishVideoModel> FindRandomByFiltersAsync(string phrase, string[] videoTypes, EnglishLevelModel[] englishLevels)
        {
            IReadOnlyList<EnglishVideoModel> englishVideos = await _videoService.FindAllByFilters(phrase, videoTypes, englishLevels);
            if (!englishVideos.Any())
                return null;

            return englishVideos.GetRandomElement();
        }

        public async Task<IReadOnlyList<EnglishVideoModel>> GetRandomAmountFromAllAsync(int amount)
        {
            IReadOnlyList<EnglishVideoModel> englishVideos = await _videoService.GetAllAsync();
            if (!englishVideos.Any())
                return englishVideos;

            return englishVideos.GetRandomCountOfElements(amount).ToList();
        }

        public async Task<IReadOnlyList<EnglishVideoModel>> FindRandomAmountByFiltersAsync(int amount, string phrase, string[] videoTypes, EnglishLevelModel[] englishLevels)
        {
            IReadOnlyList<EnglishVideoModel> englishVideos = await _videoService.FindAllByFilters(phrase, videoTypes, englishLevels);
            if (!englishLevels.Any())
                return englishVideos;

            return englishVideos.GetRandomCountOfElements(amount).ToList();
        }
    }
}