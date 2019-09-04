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
    public class RandomVideoInfoService : IRandomVideoInfoService
    {
        private readonly IVideoService _videoService;

        public RandomVideoInfoService(IVideoService videoService)
        {
            _videoService = videoService;
        }
        
        public async Task<EnglishVideoInfoModel> GetRandomInfoFromAllAsync()
        {
            IReadOnlyList<EnglishVideoInfoModel> englishVideos = await _videoService.GetAllInfoAsync();
            if (!englishVideos.Any())
            {
                return null;
            }

            return englishVideos.GetRandomElement();
        }

        public async Task<EnglishVideoInfoModel> FindRandomInfoByFiltersAsync(string phrase, string[] videoTypes, EnglishLevelModel[] englishLevels)
        {
            IReadOnlyList<EnglishVideoInfoModel> englishVideos = await _videoService.FindAllInfoByFilters(phrase, videoTypes, englishLevels);
            if (!englishVideos.Any())
            {
                return null;
            }

            return englishVideos.GetRandomElement();
        }

        public async Task<IReadOnlyList<EnglishVideoInfoModel>> GetRandomAmountInfoFromAllAsync(int amount)
        {
            IReadOnlyList<EnglishVideoInfoModel> englishVideos = await _videoService.GetAllInfoAsync();
            if (!englishVideos.Any())
            {
                return englishVideos;
            }

            return englishVideos.GetRandomCountOfElements(amount).ToList();
        }

        public async Task<IReadOnlyList<EnglishVideoInfoModel>> FindRandomAmountInfoByFiltersAsync(
            int amount, 
            string phrase, 
            string[] videoTypes,
            EnglishLevelModel[] englishLevels)
        {
            IReadOnlyList<EnglishVideoInfoModel> englishVideos = await _videoService.FindAllInfoByFilters(phrase, videoTypes, englishLevels);
            if (!englishVideos.Any())
            {
                return englishVideos;
            }

            return englishVideos.GetRandomCountOfElements(amount).ToList();
        }
    }
}