using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EnglishLearning.Multimedia.Application.Abstract.Random;
using EnglishLearning.Multimedia.Application.Models;
using EnglishLearning.Multimedia.Application.Models.Enums;
using EnglishLearning.Multimedia.Web.Infrastructure;
using EnglishLearning.Multimedia.Web.ViewModels;
using EnglishLearning.Multimedia.Web.ViewModels.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnglishLearning.Multimedia.Web.Controllers.Random
{
    [Route("/api/multimedia/random/text")]
    public class EnglishTextRandomController : Controller
    {
        private readonly IRandomTextService _randomTextService;
        private readonly IMapper _mapper;

        public EnglishTextRandomController(IRandomTextService randomTextService, WebMapper webMapper)
        {
            _randomTextService = randomTextService;
            _mapper = webMapper.Mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> GetRandomFromAll()
        {
            EnglishTextModel englishText = await _randomTextService.GetRandomFromAllAsync();
            var englishTextViewModel = _mapper.Map<EnglishTextViewModel>(englishText);
            
            return Ok(englishTextViewModel);
        }

        [AllowAnonymous]
        [HttpGet("{amount}")]
        public async Task<ActionResult> GetRandomAmountFromAll(int amount)
        {
            IReadOnlyList<EnglishTextModel> englishTexts = await _randomTextService.GetRandomAmountFromAllAsync(amount);
            var englishTextViewModels = _mapper.Map<IEnumerable<EnglishTextViewModel>>(englishTexts);

            return Ok(englishTexts);
        }

        [AllowAnonymous]
        [HttpGet("~/api/multimedia/random/search/text")]
        public async Task<ActionResult> FindRandomByFilter(
            [FromQuery] string phrase,
            [FromQuery] string[] textType,
            [FromQuery] EnglishLevelViewModel[] englishLevel)
        {
            var englishLevelModels = _mapper.Map<EnglishLevelModel[]>(englishLevel);

            EnglishTextModel englishText = await _randomTextService.FindRandomByFiltersAsync(phrase, textType, englishLevelModels);
            if (englishText == null)
                return NotFound();
            
            var englishTextViewModel = _mapper.Map<EnglishTextViewModel>(englishText);
            
            return Ok(englishTextViewModel);
        }
        
        [AllowAnonymous]
        [HttpGet("~/api/multimedia/random/search/text/{amount}")]
        public async Task<ActionResult> FindRandomAmountByFilter(
            int amount,
            [FromQuery] string phrase,
            [FromQuery] string[] textType,
            [FromQuery] EnglishLevelViewModel[] englishLevel)
        {
            var englishLevelModels = _mapper.Map<EnglishLevelModel[]>(englishLevel);

            IReadOnlyList<EnglishTextModel> englishTexts = await _randomTextService.FindRandomAmountByFiltersAsync(amount, phrase, textType, englishLevelModels);
            if (englishTexts == null)
                return NotFound();
            
            var englishTextViewModels = _mapper.Map<IEnumerable<EnglishTextViewModel>>(englishTexts);
            
            return Ok(englishTextViewModels);
        }
    }
}