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
    [Route("/api/multimedia/filters/video")]
    public class EnglishVideoFiltersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEnglishVideoFilterService _filterService;

        public EnglishVideoFiltersController(IEnglishVideoFilterService filterService, WebMapper webMapper)
        {
            _filterService = filterService;
            _mapper = webMapper.Mapper;
        }
        
        [AllowAnonymous]
        [HttpGet("types")]
        public async Task<IActionResult> GetVideoTypeFilter()
        {
            VideoTypeFilterModel filter = _filterService.GetVideoTypeFilter();
            var filterViewModels = _mapper.Map<VideoTypeFilterViewModel>(filter);

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
        public async Task<IActionResult> GetEnglishVideoFullFilter()
        {
            EnglishVideoFullFilterModel filter = _filterService.GetEnglishVideoFullFilter();
            var filterViewModels = _mapper.Map<EnglishVideoFullFilterViewModel>(filter);

            return Ok(filterViewModels);
        }
    }
}