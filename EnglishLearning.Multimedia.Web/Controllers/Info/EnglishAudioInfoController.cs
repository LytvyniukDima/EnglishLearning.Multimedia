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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnglishLearning.Multimedia.Web.Controllers.Info
{
    [Route("/api/multimedia/info/audio")]
    public class EnglishAudioInfoController : Controller
    {
        private readonly IAudioService _audioService;
        private readonly IMapper _mapper;

        public EnglishAudioInfoController(IAudioService audioService, WebMapper webMapper)
        {
            _audioService = audioService;
            _mapper = webMapper.Mapper;
        }
        
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllInfo()
        {
            IReadOnlyList<EnglishAudioInfoModel> englishAudioModels = await _audioService.GetInfoAllAsync();
            var englishAudioViewModels = _mapper.Map<IEnumerable<EnglishAudioInfoViewModel>>(englishAudioModels);

            return Ok(englishAudioViewModels);
        }
        
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInfoById(string id)
        {
            EnglishAudioInfoModel englishAudio = await _audioService.GetInfoByIdAsync(id);
            if (englishAudio == null)
                return NotFound();

            var englishAudioViewModel = _mapper.Map<EnglishAudioInfoViewModel>(englishAudio);
            
            return Ok(englishAudioViewModel);
        }
        
        [AllowAnonymous]
        [HttpGet("~/api/multimedia/search/info/audio")]
        public async Task<ActionResult> GetAllByFilter(
            [FromQuery] string phrase,
            [FromQuery] string[] audioType,
            [FromQuery] EnglishLevelViewModel[] englishLevel)
        {
            var englishLevelModels = _mapper.Map<EnglishLevelModel[]>(englishLevel);
            
            IReadOnlyList<EnglishAudioInfoModel> englishAudioModels = await _audioService.FindAllInfoByFilters(phrase, audioType, englishLevelModels);
            if (!englishAudioModels.Any())
                return NotFound();

            var englishAudioViewModels = _mapper.Map<IEnumerable<EnglishAudioInfoViewModel>>(englishAudioModels);
            
            return Ok(englishAudioViewModels);
        }
    }
}
