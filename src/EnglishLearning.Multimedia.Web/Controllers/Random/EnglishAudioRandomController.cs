using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EnglishLearning.Multimedia.Application.Abstract.Random;
using EnglishLearning.Multimedia.Application.Models;
using EnglishLearning.Multimedia.Application.Models.Enums;
using EnglishLearning.Multimedia.Web.Infrastructure;
using EnglishLearning.Multimedia.Web.ViewModels;
using EnglishLearning.Multimedia.Web.ViewModels.Enums;
using Microsoft.AspNetCore.Mvc;

namespace EnglishLearning.Multimedia.Web.Controllers.Random
{
    [Route("/api/multimedia/random/audio")]
    public class EnglishAudioRandomController : Controller
    {
        private readonly IRandomAudioService _randomAudioService;
        private readonly IMapper _mapper;

        public EnglishAudioRandomController(IRandomAudioService randomAudioService, WebMapper webMapper)
        {
            _randomAudioService = randomAudioService;
            _mapper = webMapper.Mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetRandomFromAll()
        {
            EnglishAudioModel englishAudio = await _randomAudioService.GetRandomFromAllAsync();
            var englishAudioViewModel = _mapper.Map<EnglishAudioViewModel>(englishAudio);
            
            return Ok(englishAudioViewModel);
        }

        [HttpGet("{amount}")]
        public async Task<ActionResult> GetRandomAmountFromAll(int amount)
        {
            IReadOnlyList<EnglishAudioModel> englishAudios = await _randomAudioService.GetRandomAmountFromAllAsync(amount);
            var englishAudioViewModels = _mapper.Map<IEnumerable<EnglishAudioViewModel>>(englishAudios);

            return Ok(englishAudioViewModels);
        }

        [HttpGet("~/api/multimedia/random/search/audio")]
        public async Task<ActionResult> FindRandomByFilter(
            [FromQuery] string phrase,
            [FromQuery] string[] audioType,
            [FromQuery] EnglishLevelViewModel[] englishLevel)
        {
            var englishLevelModels = _mapper.Map<EnglishLevelModel[]>(englishLevel);

            EnglishAudioModel englishAudio = await _randomAudioService.FindRandomByFiltersAsync(phrase, audioType, englishLevelModels);
            if (englishAudio == null)
            {
                return NotFound();
            }

            var englishAudioViewModel = _mapper.Map<EnglishAudioViewModel>(englishAudio);
            
            return Ok(englishAudioViewModel);
        }
        
        [HttpGet("~/api/multimedia/random/search/audio/{amount}")]
        public async Task<ActionResult> FindRandomAmountByFilter(
            int amount,
            [FromQuery] string phrase,
            [FromQuery] string[] audioType,
            [FromQuery] EnglishLevelViewModel[] englishLevel)
        {
            var englishLevelModels = _mapper.Map<EnglishLevelModel[]>(englishLevel);

            IReadOnlyList<EnglishAudioModel> englishAudios = await _randomAudioService.FindRandomAmountByFiltersAsync(amount, phrase, audioType, englishLevelModels);
            if (englishAudios == null)
            {
                return NotFound();
            }

            var englishAudioViewModels = _mapper.Map<IEnumerable<EnglishAudioViewModel>>(englishAudios);
            
            return Ok(englishAudioViewModels);
        }
    }
}
