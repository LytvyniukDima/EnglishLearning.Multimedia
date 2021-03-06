﻿using System.Collections.Generic;
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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnglishLearning.Multimedia.Web.Controllers
{
    [Route("/api/multimedia/video")]
    public class EnglishVideoController : Controller
    {
        private readonly IVideoService _videoService;
        private readonly IMapper _mapper;

        public EnglishVideoController(IVideoService videoService, WebMapper webMapper)
        {
            _videoService = videoService;
            _mapper = webMapper.Mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IReadOnlyList<EnglishVideoModel> englishVideoModels = await _videoService.GetAllAsync();
            var englishVideoViewModels = _mapper.Map<IReadOnlyList<EnglishVideoViewModel>>(englishVideoModels);

            return Ok(englishVideoViewModels);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            EnglishVideoModel englishVideo = await _videoService.GetByIdAsync(id);
            if (englishVideo == null)
            {
                return NotFound();
            }

            var englishVideoViewModel = _mapper.Map<EnglishVideoViewModel>(englishVideo);
            
            return Ok(englishVideoViewModel);
        }
        
        [EnglishLearningAuthorize(AuthorizeRole.Admin)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EnglishVideoCreateViewModel englishVideoCreateViewModel)
        {
            var englishVideoCreateModel = _mapper.Map<EnglishVideoCreateModel>(englishVideoCreateViewModel);
            
            await _videoService.CreateAsync(englishVideoCreateModel);

            return Ok();
        }
        
        [EnglishLearningAuthorize(AuthorizeRole.Admin)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] EnglishVideoViewModel englishVideoViewModel)
        {
            var englishVideoCreateModel = _mapper.Map<EnglishVideoModel>(englishVideoViewModel);

            bool result = await _videoService.UpdateAsync(id, englishVideoCreateModel);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }
        
        [EnglishLearningAuthorize(AuthorizeRole.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(string id)
        {
            bool result = await _videoService.DeleteByIdAsync(id);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }
        
        [EnglishLearningAuthorize(AuthorizeRole.Admin)]
        [HttpDelete]
        public async Task<IActionResult> DeleteAll()
        {
            bool result = await _videoService.DeleteAllAsync();

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }
        
        [AllowAnonymous]
        [HttpGet("~/api/multimedia/search/video")]
        public async Task<ActionResult> GetAllByFilter(
            [FromQuery] string phrase,
            [FromQuery] string[] videoType,
            [FromQuery] EnglishLevelViewModel[] englishLevel)
        {
            var englishLevelModels = _mapper.Map<EnglishLevelModel[]>(englishLevel);
            
            IReadOnlyList<EnglishVideoModel> englishVideoModels = await _videoService.FindAllByFilters(phrase, videoType, englishLevelModels);
            if (!englishVideoModels.Any())
            {
                return NotFound();
            }

            var englishVideoViewModels = _mapper.Map<IEnumerable<EnglishVideoViewModel>>(englishVideoModels);
            
            return Ok(englishVideoViewModels);
        }
    }
}
