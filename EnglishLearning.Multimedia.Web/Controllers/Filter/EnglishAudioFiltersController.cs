using System.Threading.Tasks;
using AutoMapper;
using EnglishLearning.Multimedia.Application.Abstract.Filters;
using EnglishLearning.Multimedia.Application.Models.Filters;
using EnglishLearning.Multimedia.Web.Infrastructure;
using EnglishLearning.Multimedia.Web.ViewModels.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnglishLearning.Multimedia.Web.Controllers.Filter
{
    [Route("/api/multimedia/filters/audio")]
    public class EnglishAudioFiltersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEnglishAudioFilterService _filterService;

        public EnglishAudioFiltersController(IEnglishAudioFilterService filterService, WebMapper webMapper)
        {
            _filterService = filterService;
            _mapper = webMapper.Mapper;
        }
        
        [AllowAnonymous]
        [HttpGet("player_types")]
        public async Task<IActionResult> GetAudioPlayerTypeFilter()
        {
            AudioPlayerTypeFilterModel filter = _filterService.GetAudioPlayerTypeFilter();
            var filterViewModels = _mapper.Map<AudioPlayerTypeFilterViewModel>(filter);

            return Ok(filterViewModels);
        }
        
        [AllowAnonymous]
        [HttpGet("types")]
        public async Task<IActionResult> GetAudioTypeFilter()
        {
            AudioTypeFilterModel filter = _filterService.GetAudioTypeFilter();
            var filterViewModels = _mapper.Map<AudioTypeFilterViewModel>(filter);

            return Ok(filterViewModels);
        }
        
        [AllowAnonymous]
        [HttpGet("english_levels")]
        public async Task<IActionResult> GetEnglishLevelFilter()
        {
            EnglishLevelFilterModel filter = _filterService.GetEnglishLevelFilter();
            var filterViewModels = _mapper.Map<EnglishLevelFilterViewModel>(filter);

            return Ok(filterViewModels);
        }
        
        [AllowAnonymous]
        [HttpGet("full")]
        public async Task<IActionResult> GetEnglishAudioFullFilter()
        {
            EnglishAudioFullFilterModel filter = _filterService.GetEnglishAudioFullFilter();
            var filterViewModels = _mapper.Map<EnglishAudioFullFilterViewModel>(filter);

            return Ok(filterViewModels);
        }
    }
}