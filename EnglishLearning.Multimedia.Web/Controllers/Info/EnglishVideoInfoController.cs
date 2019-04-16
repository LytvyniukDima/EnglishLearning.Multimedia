using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EnglishLearning.Multimedia.Application.Abstract;
using EnglishLearning.Multimedia.Application.Models.Enums;
using EnglishLearning.Multimedia.Application.Models.InfoModels;
using EnglishLearning.Multimedia.Web.Infrastructure;
using EnglishLearning.Multimedia.Web.ViewModels.Enums;
using EnglishLearning.Multimedia.Web.ViewModels.Info;
using Microsoft.AspNetCore.Mvc;

namespace EnglishLearning.Multimedia.Web.Controllers.Info
{
    [Route("/api/multimedia/info/video")]
    public class EnglishVideoInfoController : Controller
    {
        private readonly IVideoService _videoService;
        private readonly IMapper _mapper;

        public EnglishVideoInfoController(IVideoService videoService, WebMapper webMapper)
        {
            _videoService = videoService;
            _mapper = webMapper.Mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllInfo()
        {
            IReadOnlyList<EnglishVideoInfoModel> englishVideoModels = await _videoService.GetAllInfoAsync();
            var englishVideoViewModels = _mapper.Map<IEnumerable<EnglishVideoInfoViewModel>>(englishVideoModels);

            return Ok(englishVideoViewModels);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInfoById(string id)
        {
            EnglishVideoInfoModel englishVideo = await _videoService.GetInfoByIdAsync(id);
            if (englishVideo == null)
                return NotFound();

            var englishVideoViewModel = _mapper.Map<EnglishVideoInfoViewModel>(englishVideo);
            
            return Ok(englishVideoViewModel);
        }
        
        [HttpGet("~/api/multimedia/search/info/video")]
        public async Task<ActionResult> GetAllByFilter(
            [FromQuery] string phrase,
            [FromQuery] string[] videoType,
            [FromQuery] EnglishLevelViewModel[] englishLevel)
        {
            var englishLevelModels = _mapper.Map<EnglishLevelModel[]>(englishLevel);
            
            IReadOnlyList<EnglishVideoInfoModel> englishVideoModels = await _videoService.FindAllInfoByFilters(phrase, videoType, englishLevelModels);
            if (!englishVideoModels.Any())
                return NotFound();

            var englishVideoViewModels = _mapper.Map<IEnumerable<EnglishVideoInfoViewModel>>(englishVideoModels);
            
            return Ok(englishVideoViewModels);
        } 
    }
}