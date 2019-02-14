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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnglishLearning.Multimedia.Web.Controllers
{
    [Route("/api/multimedia/audio")]
    public class EnglishAudioController : Controller
    {
        private readonly IAudioService _audioService;
        private readonly IMapper _mapper;

        public EnglishAudioController(IAudioService audioService, WebMapper webMapper)
        {
            _audioService = audioService;
            _mapper = webMapper.Mapper;
        }
        
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IReadOnlyList<EnglishAudioModel> englishAudioModels = await _audioService.GetAllAsync();
            var englishAudioViewModels = _mapper.Map<IReadOnlyList<EnglishAudioViewModel>>(englishAudioModels);

            return Ok(englishAudioViewModels);
        }
        
        [AllowAnonymous]
        [HttpGet("/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            EnglishAudioModel englishAudio = await _audioService.GetByIdAsync(id);
            if (englishAudio == null)
                return NotFound();

            var englishAudioViewModel = _mapper.Map<EnglishAudioViewModel>(englishAudio);
            
            return Ok(englishAudioViewModel);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EnglishAudioCreateViewModel englishAudioCreateViewModel)
        {
            var englishAudioCreateModel = _mapper.Map<EnglishAudioCreateModel>(englishAudioCreateViewModel);
            
            await _audioService.CreateAsync(englishAudioCreateModel);

            return Ok();
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] EnglishAudioViewModel englishAudioViewModel)
        {
            var englishAudioCreateModel = _mapper.Map<EnglishAudioModel>(englishAudioViewModel);

            bool result = await _audioService.UpdateAsync(id, englishAudioCreateModel);

            if (result == false)
                return BadRequest();
            
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            bool result = await _audioService.DeleteByIdAsync(id);

            if (result == false)
                return BadRequest();
            
            return Ok();
        }
        
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            bool result = await _audioService.DeleteAllAsync();

            if (result == false)
                return BadRequest();
            
            return Ok();
        }
        
        [AllowAnonymous]
        [HttpGet("~/api/multimedia/search/audio")]
        public async Task<ActionResult> GetAllByFilter(
            [FromQuery] string phrase,
            [FromQuery] string[] audioType,
            [FromQuery] EnglishLevelViewModel[] englishLevel)
        {
            var englishLevelModels = _mapper.Map<EnglishLevelModel[]>(englishLevel);
            
            IReadOnlyList<EnglishAudioModel> englishTakModels = await _audioService.FindAllByFilters(phrase, audioType, englishLevelModels);
            if (!englishTakModels.Any())
                return NotFound();

            var englishAudioViewModels = _mapper.Map<IEnumerable<EnglishAudioViewModel>>(englishTakModels);
            
            return Ok(englishAudioViewModels);
        }
    }
}
