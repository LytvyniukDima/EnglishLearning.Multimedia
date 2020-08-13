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
    [Route("/api/multimedia/random/video")]
    public class EnglishVideoRandomController : Controller
    {
        private readonly IRandomVideoService _randomVideoService;
        private readonly IMapper _mapper;

        public EnglishVideoRandomController(IRandomVideoService randomVideoService, WebMapper webMapper)
        {
            _randomVideoService = randomVideoService;
            _mapper = webMapper.Mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetRandomFromAll()
        {
            EnglishVideoModel englishVideo = await _randomVideoService.GetRandomFromAllAsync();
            var englishVideoViewModel = _mapper.Map<EnglishVideoViewModel>(englishVideo);
            
            return Ok(englishVideoViewModel);
        }

        [HttpGet("{amount}")]
        public async Task<ActionResult> GetRandomAmountFromAll(int amount)
        {
            IReadOnlyList<EnglishVideoModel> englishVideos = await _randomVideoService.GetRandomAmountFromAllAsync(amount);
            var englishVideoViewModels = _mapper.Map<IEnumerable<EnglishVideoViewModel>>(englishVideos);

            return Ok(englishVideoViewModels);
        }

        [HttpGet("~/api/multimedia/random/search/video")]
        public async Task<ActionResult> FindRandomByFilter(
            [FromQuery] string phrase,
            [FromQuery] string[] videoType,
            [FromQuery] EnglishLevelViewModel[] englishLevel)
        {
            var englishLevelModels = _mapper.Map<EnglishLevelModel[]>(englishLevel);

            EnglishVideoModel englishVideo = await _randomVideoService.FindRandomByFiltersAsync(phrase, videoType, englishLevelModels);
            if (englishVideo == null)
            {
                return NotFound();
            }

            var englishVideoViewModel = _mapper.Map<EnglishVideoViewModel>(englishVideo);
            
            return Ok(englishVideoViewModel);
        }
        
        [HttpGet("~/api/multimedia/random/search/video/{amount}")]
        public async Task<ActionResult> FindRandomAmountByFilter(
            int amount,
            [FromQuery] string phrase,
            [FromQuery] string[] videoType,
            [FromQuery] EnglishLevelViewModel[] englishLevel)
        {
            var englishLevelModels = _mapper.Map<EnglishLevelModel[]>(englishLevel);

            IReadOnlyList<EnglishVideoModel> englishVideos = await _randomVideoService.FindRandomAmountByFiltersAsync(amount, phrase, videoType, englishLevelModels);
            if (englishVideos == null)
            {
                return NotFound();
            }

            var englishVideoViewModels = _mapper.Map<IEnumerable<EnglishVideoViewModel>>(englishVideos);
            
            return Ok(englishVideoViewModels);
        }
    }
}
