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
    public class RandomTextService : IRandomTextService
    {
        private readonly ITextService _textService;

        public RandomTextService(ITextService textService)
        {
            _textService = textService;
        }
        
        public async Task<EnglishTextModel> GetRandomFromAllAsync()
        {
            IReadOnlyList<EnglishTextModel> englishTexts = await _textService.GetAllAsync();
            if (!englishTexts.Any())
                return null;

            return englishTexts.GetRandomElement();
        }

        public async Task<EnglishTextModel> FindRandomByPhraseAsync(int amount, string phrase)
        {
            IReadOnlyList<EnglishTextModel> englishTexts = await _textService.FindAllByPhrase(phrase);
            if (!englishTexts.Any())
                return null;

            return englishTexts.GetRandomElement();
        }

        public async Task<EnglishTextModel> FindRandomByFiltersAsync(int amount, string[] textTypes, EnglishLevelModel[] englishLevels)
        {
            IReadOnlyList<EnglishTextModel> englishTexts = await _textService.FindAllByFilters(textTypes, englishLevels);
            if (!englishTexts.Any())
                return null;

            return englishTexts.GetRandomElement();
        }

        public async Task<EnglishTextModel> FindRandomByFiltersAsync(int amount, string phrase, string[] textTypes, EnglishLevelModel[] englishLevels)
        {
            IReadOnlyList<EnglishTextModel> englishTexts = await _textService.FindAllByFilters(phrase, textTypes, englishLevels);
            if (!englishTexts.Any())
                return null;

            return englishTexts.GetRandomElement();
        }

        public async Task<IReadOnlyList<EnglishTextModel>> GetRandomAmountFromAllAsync(int amount)
        {
            IReadOnlyList<EnglishTextModel> englishTexts = await _textService.GetAllAsync();
            if (!englishTexts.Any())
                return englishTexts;

            return englishTexts.GetRandomCountOfElements(amount).ToList();
        }

        public async Task<IReadOnlyList<EnglishTextModel>> FindRandomAmountByPhraseAsync(int amount, string phrase)
        {
            IReadOnlyList<EnglishTextModel> englishTexts = await _textService.FindAllByPhrase(phrase);
            if (!englishTexts.Any())
                return englishTexts;

            return englishTexts.GetRandomCountOfElements(amount).ToList();
        }

        public async Task<IReadOnlyList<EnglishTextModel>> FindRandomAmountByFiltersAsync(int amount, string[] textTypes, EnglishLevelModel[] englishLevels)
        {
            IReadOnlyList<EnglishTextModel> englishTexts = await _textService.FindAllByFilters(textTypes, englishLevels);
            if (!englishTexts.Any())
                return englishTexts;

            return englishTexts.GetRandomCountOfElements(amount).ToList();
        }

        public async Task<IReadOnlyList<EnglishTextModel>> FindRandomAmountByFiltersAsync(int amount, string phrase, string[] textTypes, EnglishLevelModel[] englishLevels)
        {
            IReadOnlyList<EnglishTextModel> englishTexts = await _textService.FindAllByFilters(phrase, textTypes, englishLevels);
            if (!englishTexts.Any())
                return englishTexts;

            return englishTexts.GetRandomCountOfElements(amount).ToList();
        }
    }
}