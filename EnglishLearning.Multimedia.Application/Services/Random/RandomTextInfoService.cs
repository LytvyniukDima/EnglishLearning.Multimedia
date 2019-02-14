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
    public class RandomTextInfoService : IRandomTextInfoService
    {
        private readonly ITextService _textService;
        
        public RandomTextInfoService(ITextService textService)
        {
            _textService = textService;
        }
        
        public async Task<EnglishTextInfoModel> GetRandomInfoFromAllAsync()
        {
            IReadOnlyList<EnglishTextInfoModel> englishTexts = await _textService.GetAllInfoAsync();
            if (!englishTexts.Any())
                return null;

            return englishTexts.GetRandomElement();
        }

        public async Task<EnglishTextInfoModel> FindRandomInfoByFiltersAsync(string phrase, string[] textTypes, EnglishLevelModel[] englishLevels)
        {
            IReadOnlyList<EnglishTextInfoModel> englishTexts = await _textService.FindAllInfoByFilters(phrase, textTypes, englishLevels);
            if (!englishTexts.Any())
                return null;

            return englishTexts.GetRandomElement();
        }

        public async Task<IReadOnlyList<EnglishTextInfoModel>> GetRandomAmountInfoFromAllAsync(int amount)
        {
            IReadOnlyList<EnglishTextInfoModel> englishTexts = await _textService.GetAllInfoAsync();
            if (!englishTexts.Any())
                return englishTexts;

            return englishTexts.GetRandomCountOfElements(amount).ToList();
        }

        public async Task<IReadOnlyList<EnglishTextInfoModel>> FindRandomAmountInfoByFiltersAsync(int amount, string phrase, string[] textTypes,
            EnglishLevelModel[] englishLevels)
        {
            IReadOnlyList<EnglishTextInfoModel> englishTexts = await _textService.FindAllInfoByFilters(phrase, textTypes, englishLevels);
            if (!englishTexts.Any())
                return englishTexts;

            return englishTexts.GetRandomCountOfElements(amount).ToList();
        }
    }
}