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
    [Route("/api/multimedia/random/info/audio")]
    public class EnglishAudioRandomInfoController : Controller
    {
        private readonly IRandomAudioInfoService _randomAudioInfoService;
        private readonly IMapper _mapper;

        public EnglishAudioRandomInfoController(IRandomAudioInfoService randomAudioInfoService, WebMapper webMapper)
        {
            _randomAudioInfoService = randomAudioInfoService;
            _mapper = webMapper.Mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> GetRandomFromAll()
        {
            EnglishAudioInfoModel englishAudio = await _randomAudioInfoService.GetRandomInfoFromAllAsync();
            var englishAudioViewModel = _mapper.Map<EnglishAudioInfoViewModel>(englishAudio);
            
            return Ok(englishAudioViewModel);
        }

        [AllowAnonymous]
        [HttpGet("{amount}")]
        public async Task<ActionResult> GetRandomAmountFromAll(int amount)
        {
            IReadOnlyList<EnglishAudioInfoModel> englishAudios = await _randomAudioInfoService.GetRandomAmountInfoFromAllAsync(amount);
            var englishAudioViewModels = _mapper.Map<IEnumerable<EnglishAudioInfoViewModel>>(englishAudios);

            return Ok(englishAudios);
        }

        [AllowAnonymous]
        [HttpGet("~/api/multimedia/random/info/search/audio")]
        public async Task<ActionResult> FindRandomByFilter(
            [FromQuery] string phrase,
            [FromQuery] string[] audioType,
            [FromQuery] EnglishLevelViewModel[] englishLevel)
        {
            var englishLevelModels = _mapper.Map<EnglishLevelModel[]>(englishLevel);

            EnglishAudioInfoModel englishAudio = await _randomAudioInfoService.FindRandomInfoByFiltersAsync(phrase, audioType, englishLevelModels);
            if (englishAudio == null)
                return NotFound();
            
            var englishAudioViewModel = _mapper.Map<EnglishAudioInfoViewModel>(englishAudio);
            
            return Ok(englishAudioViewModel);
        }
        
        [AllowAnonymous]
        [HttpGet("~/api/multimedia/random/info/search/audio/{amount}")]
        public async Task<ActionResult> FindRandomAmountByFilter(
            int amount,
            [FromQuery] string phrase,
            [FromQuery] string[] audioType,
            [FromQuery] EnglishLevelViewModel[] englishLevel)
        {
            var englishLevelModels = _mapper.Map<EnglishLevelModel[]>(englishLevel);

            IReadOnlyList<EnglishAudioInfoModel> englishAudios = await _randomAudioInfoService.FindRandomAmountInfoByFiltersAsync(amount, phrase, audioType, englishLevelModels);
            if (englishAudios == null)
                return NotFound();
            
            var englishAudioViewModels = _mapper.Map<IEnumerable<EnglishAudioInfoViewModel>>(englishAudios);
            
            return Ok(englishAudioViewModels);
        }
    }
}