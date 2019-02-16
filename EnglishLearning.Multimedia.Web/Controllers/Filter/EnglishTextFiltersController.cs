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
    [Route("/api/multimedia/filters/text")]
    public class EnglishTextFiltersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEnglishTextFilterService _filterService;

        public EnglishTextFiltersController(IEnglishTextFilterService filterService, WebMapper webMapper)
        {
            _filterService = filterService;
            _mapper = webMapper.Mapper;
        }
        
        [AllowAnonymous]
        [HttpGet("types")]
        public async Task<IActionResult> GetTextTypeFilter()
        {
            TextTypeFilterModel filter = _filterService.GetTextTypeFilter();
            var filterViewModels = _mapper.Map<TextTypeFilterViewModel>(filter);

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
        public async Task<IActionResult> GetEnglishTextFullFilter()
        {
            EnglishTextFullFilterModel filter = _filterService.GetEnglishTextFullFilter();
            var filterViewModels = _mapper.Map<EnglishTextFullFilterViewModel>(filter);

            return Ok(filterViewModels);
        }
    }
}