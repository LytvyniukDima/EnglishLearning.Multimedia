using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EnglishLearning.Multimedia.Application.Abstract.Random;
using EnglishLearning.Multimedia.Application.Models.Enums;
using EnglishLearning.Multimedia.Application.Models.InfoModels;
using EnglishLearning.Multimedia.Web.Infrastructure;
using EnglishLearning.Multimedia.Web.ViewModels.Enums;
using EnglishLearning.Multimedia.Web.ViewModels.Info;
using Microsoft.AspNetCore.Mvc;

namespace EnglishLearning.Multimedia.Web.Controllers.Random
{
    [Route("/api/multimedia/random/info/video")]
    public class EnglishVideoRandomInfoController : Controller
    {
        private readonly IRandomVideoInfoService _randomVideoInfoService;
        private readonly IMapper _mapper;

        public EnglishVideoRandomInfoController(IRandomVideoInfoService randomVideoInfoService, WebMapper webMapper)
        {
            _randomVideoInfoService = randomVideoInfoService;
            _mapper = webMapper.Mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetRandomFromAll()
        {
            EnglishVideoInfoModel englishVideo = await _randomVideoInfoService.GetRandomInfoFromAllAsync();
            var englishVideoViewModel = _mapper.Map<EnglishVideoInfoViewModel>(englishVideo);
            
            return Ok(englishVideoViewModel);
        }

        [HttpGet("{amount}")]
        public async Task<ActionResult> GetRandomAmountFromAll(int amount)
        {
            IReadOnlyList<EnglishVideoInfoModel> englishVideos = await _randomVideoInfoService.GetRandomAmountInfoFromAllAsync(amount);
            var englishVideoViewModels = _mapper.Map<IEnumerable<EnglishVideoInfoViewModel>>(englishVideos);

            return Ok(englishVideoViewModels);
        }

        [HttpGet("~/api/multimedia/random/info/search/video")]
        public async Task<ActionResult> FindRandomByFilter(
            [FromQuery] string phrase,
            [FromQuery] string[] videoType,
            [FromQuery] EnglishLevelViewModel[] englishLevel)
        {
            var englishLevelModels = _mapper.Map<EnglishLevelModel[]>(englishLevel);

            EnglishVideoInfoModel englishVideo = await _randomVideoInfoService.FindRandomInfoByFiltersAsync(phrase, videoType, englishLevelModels);
            if (englishVideo == null)
            {
                return NotFound();
            }

            var englishVideoViewModel = _mapper.Map<EnglishVideoInfoViewModel>(englishVideo);
            
            return Ok(englishVideoViewModel);
        }
        
        [HttpGet("~/api/multimedia/random/info/search/video/{amount}")]
        public async Task<ActionResult> FindRandomAmountByFilter(
            int amount,
            [FromQuery] string phrase,
            [FromQuery] string[] videoType,
            [FromQuery] EnglishLevelViewModel[] englishLevel)
        {
            var englishLevelModels = _mapper.Map<EnglishLevelModel[]>(englishLevel);

            IReadOnlyList<EnglishVideoInfoModel> englishVideos = await _randomVideoInfoService.FindRandomAmountInfoByFiltersAsync(amount, phrase, videoType, englishLevelModels);
            if (englishVideos == null)
            {
                return NotFound();
            }

            var englishVideoViewModels = _mapper.Map<IEnumerable<EnglishVideoInfoViewModel>>(englishVideos);
            
            return Ok(englishVideoViewModels);
        }
    }
}
