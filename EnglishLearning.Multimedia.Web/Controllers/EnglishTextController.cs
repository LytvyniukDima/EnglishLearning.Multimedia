using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EnglishLearning.Multimedia.Application.Abstract;
using EnglishLearning.Multimedia.Application.Models;
using EnglishLearning.Multimedia.Application.Models.CreateModels;
using EnglishLearning.Multimedia.Application.Models.Enums;
using EnglishLearning.Multimedia.Web.Infrastructure;
using EnglishLearning.Multimedia.Web.ViewModels;
using EnglishLearning.Multimedia.Web.ViewModels.Create;
using EnglishLearning.Multimedia.Web.ViewModels.Enums;
using EnglishLearning.Utilities.Identity.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace EnglishLearning.Multimedia.Web.Controllers
{
    [Route("/api/multimedia/text")]
    public class EnglishTextController : Controller 
    {
        private readonly ITextService _textService;
        private readonly IMapper _mapper;

        public EnglishTextController(ITextService textService, WebMapper webMapper)
        {
            _textService = textService;
            _mapper = webMapper.Mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IReadOnlyList<EnglishTextModel> englishTextModels = await _textService.GetAllAsync();
            var englishTextViewModels = _mapper.Map<IReadOnlyList<EnglishTextViewModel>>(englishTextModels);

            return Ok(englishTextViewModels);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            EnglishTextModel englishText = await _textService.GetByIdAsync(id);
            if (englishText == null)
            {
                return NotFound();
            }

            var englishTextViewModel = _mapper.Map<EnglishTextViewModel>(englishText);
            
            return Ok(englishTextViewModel);
        }
        
        [EnglishLearningAuthorize(AuthorizeRole.Admin)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EnglishTextCreateViewModel englishTextCreateViewModel)
        {
            var englishTextCreateModel = _mapper.Map<EnglishTextCreateModel>(englishTextCreateViewModel);
            
            await _textService.CreateAsync(englishTextCreateModel);

            return Ok();
        }
        
        [EnglishLearningAuthorize(AuthorizeRole.Admin)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] EnglishTextViewModel englishTextViewModel)
        {
            var englishTextCreateModel = _mapper.Map<EnglishTextModel>(englishTextViewModel);

            bool result = await _textService.UpdateAsync(id, englishTextCreateModel);

            if (result == false)
            {
                return BadRequest();
            }

            return Ok();
        }
        
        [EnglishLearningAuthorize(AuthorizeRole.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(string id)
        {
            bool result = await _textService.DeleteByIdAsync(id);

            if (result == false)
            {
                return BadRequest();
            }

            return Ok();
        }
        
        [EnglishLearningAuthorize(AuthorizeRole.Admin)]
        [HttpDelete]
        public async Task<IActionResult> DeleteAll()
        {
            bool result = await _textService.DeleteAllAsync();

            if (result == false)
            {
                return BadRequest();
            }

            return Ok();
        }
        
        [HttpGet("~/api/multimedia/search/text")]
        public async Task<ActionResult> GetAllByFilter(
            [FromQuery] string phrase,
            [FromQuery] string[] textType,
            [FromQuery] EnglishLevelViewModel[] englishLevel)
        {
            var englishLevelModels = _mapper.Map<EnglishLevelModel[]>(englishLevel);
            
            IReadOnlyList<EnglishTextModel> englishTextModels = await _textService.FindAllByFilters(phrase, textType, englishLevelModels);
            if (!englishTextModels.Any())
            {
                return NotFound();
            }

            var englishTextViewModels = _mapper.Map<IEnumerable<EnglishTextViewModel>>(englishTextModels);
            
            return Ok(englishTextViewModels);
        }
    }
}
