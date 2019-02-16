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
    [Route("/api/multimedia/info/text")]
    public class EnglishTextInfoController : Controller
    {
        private readonly ITextService _textService;
        private readonly IMapper _mapper;

        public EnglishTextInfoController(ITextService textService, WebMapper webMapper)
        {
            _textService = textService;
            _mapper = webMapper.Mapper;
        }
        
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllInfo()
        {
            IReadOnlyList<EnglishTextInfoModel> englishTextModels = await _textService.GetAllInfoAsync();
            var englishTextViewModels = _mapper.Map<IEnumerable<EnglishTextInfoViewModel>>(englishTextModels);

            return Ok(englishTextViewModels);
        }
        
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInfoById(string id)
        {
            EnglishTextInfoModel englishText = await _textService.GetInfoByIdAsync(id);
            if (englishText == null)
                return NotFound();

            var englishTextViewModel = _mapper.Map<EnglishTextInfoViewModel>(englishText);
            
            return Ok(englishTextViewModel);
        }
        
        [AllowAnonymous]
        [HttpGet("~/api/multimedia/search/info/text")]
        public async Task<ActionResult> GetAllByFilter(
            [FromQuery] string phrase,
            [FromQuery] string[] textType,
            [FromQuery] EnglishLevelViewModel[] englishLevel)
        {
            var englishLevelModels = _mapper.Map<EnglishLevelModel[]>(englishLevel);
            
            IReadOnlyList<EnglishTextInfoModel> englishTextModels = await _textService.FindAllInfoByFilters(phrase, textType, englishLevelModels);
            if (!englishTextModels.Any())
                return NotFound();

            var englishTextViewModels = _mapper.Map<IEnumerable<EnglishTextInfoViewModel>>(englishTextModels);
            
            return Ok(englishTextViewModels);
        } 
    }
}