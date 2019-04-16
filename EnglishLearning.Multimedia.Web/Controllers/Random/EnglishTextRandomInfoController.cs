using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EnglishLearning.Multimedia.Application.Abstract.Random;
using EnglishLearning.Multimedia.Application.Models.Enums;
using EnglishLearning.Multimedia.Application.Models.InfoModels;
using EnglishLearning.Multimedia.Web.Infrastructure;
using EnglishLearning.Multimedia.Web.ViewModels.Enums;
using EnglishLearning.Multimedia.Web.ViewModels.Info;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnglishLearning.Multimedia.Web.Controllers.Random
{
    [Route("/api/multimedia/random/info/text")]
    public class EnglishTextRandomInfoController : Controller
    {
        private readonly IRandomTextInfoService _randomTextInfoService;
        private readonly IMapper _mapper;

        public EnglishTextRandomInfoController(IRandomTextInfoService randomTextInfoService, WebMapper webMapper)
        {
            _randomTextInfoService = randomTextInfoService;
            _mapper = webMapper.Mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetRandomFromAll()
        {
            EnglishTextInfoModel englishText = await _randomTextInfoService.GetRandomInfoFromAllAsync();
            var englishTextViewModel = _mapper.Map<EnglishTextInfoViewModel>(englishText);
            
            return Ok(englishTextViewModel);
        }

        [HttpGet("{amount}")]
        public async Task<ActionResult> GetRandomAmountFromAll(int amount)
        {
            IReadOnlyList<EnglishTextInfoModel> englishTexts = await _randomTextInfoService.GetRandomAmountInfoFromAllAsync(amount);
            var englishTextViewModels = _mapper.Map<IEnumerable<EnglishTextInfoViewModel>>(englishTexts);

            return Ok(englishTexts);
        }

        [HttpGet("~/api/multimedia/random/info/search/text")]
        public async Task<ActionResult> FindRandomByFilter(
            [FromQuery] string phrase,
            [FromQuery] string[] textType,
            [FromQuery] EnglishLevelViewModel[] englishLevel)
        {
            var englishLevelModels = _mapper.Map<EnglishLevelModel[]>(englishLevel);

            EnglishTextInfoModel englishText = await _randomTextInfoService.FindRandomInfoByFiltersAsync(phrase, textType, englishLevelModels);
            if (englishText == null)
                return NotFound();
            
            var englishTextViewModel = _mapper.Map<EnglishTextInfoViewModel>(englishText);
            
            return Ok(englishTextViewModel);
        }
        
        [HttpGet("~/api/multimedia/random/info/search/text/{amount}")]
        public async Task<ActionResult> FindRandomAmountByFilter(
            int amount,
            [FromQuery] string phrase,
            [FromQuery] string[] textType,
            [FromQuery] EnglishLevelViewModel[] englishLevel)
        {
            var englishLevelModels = _mapper.Map<EnglishLevelModel[]>(englishLevel);

            IReadOnlyList<EnglishTextInfoModel> englishTexts = await _randomTextInfoService.FindRandomAmountInfoByFiltersAsync(amount, phrase, textType, englishLevelModels);
            if (englishTexts == null)
                return NotFound();
            
            var englishTextViewModels = _mapper.Map<IEnumerable<EnglishTextInfoViewModel>>(englishTexts);
            
            return Ok(englishTextViewModels);
        }
    }
}
