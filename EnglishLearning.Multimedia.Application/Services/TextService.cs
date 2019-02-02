using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EnglishLearning.Multimedia.Application.Abstract;
using EnglishLearning.Multimedia.Application.Infrastructure;
using EnglishLearning.Multimedia.Application.Models;
using EnglishLearning.Multimedia.Application.Models.CreateModels;
using EnglishLearning.Multimedia.Application.Models.Enums;
using EnglishLearning.Multimedia.Application.Models.InfoModels;
using EnglishLearning.Multimedia.Persistence.Abstract;
using EnglishLearning.Multimedia.Persistence.Entities;
using EnglishLearning.Multimedia.Persistence.Entities.Text;

namespace EnglishLearning.Multimedia.Application.Services
{
    public class TextService : ITextService
    {
        private readonly IEnglishTextRepository _englishTextRepository;
        private readonly IMapper _mapper;

        public TextService(IEnglishTextRepository englishTextRepository, ApplicationMapper applicationMapper)
        {
            _englishTextRepository = englishTextRepository;
            _mapper = applicationMapper.Mapper;
        }
        
        public async Task CreateAsync(EnglishTextCreateModel englishTextCreateModel)
        {
            var englishText = _mapper.Map<EnglishText>(englishTextCreateModel);

            await _englishTextRepository.AddAsync(englishText);
        }

        public async Task<bool> UpdateAsync(string id, EnglishTextModel englishTextModel)
        {
            var englishText = _mapper.Map<EnglishText>(englishTextModel);

            return await _englishTextRepository.UpdateAsync(id, englishText);
        }

        public async Task<EnglishTextModel> GetByIdAsync(string id)
        {
            var englishText = await _englishTextRepository.FindAsync(x => x.Id == id);

            return _mapper.Map<EnglishTextModel>(englishText);
        }

        public async Task<IReadOnlyList<EnglishTextModel>> GetAllAsync()
        {
            var englishTexts = await _englishTextRepository.GetAllAsync();

            return _mapper.Map<IReadOnlyList<EnglishTextModel>>(englishTexts);
        }

        public async Task<bool> DeleteByIdAsync(string id)
        {
            return await _englishTextRepository.DeleteAsync(x => x.Id == id);
        }

        public async Task<bool> DeleteAllAsync()
        {
            return await _englishTextRepository.DeleteAllAsync();
        }

        public async Task<EnglishTextInfoModel> GetInfoByIdAsync(string id)
        {
            var englishText = await _englishTextRepository.FindAsync(x => x.Id == id);

            return _mapper.Map<EnglishTextInfoModel>(englishText);
        }

        public async Task<IReadOnlyList<EnglishTextInfoModel>> GetAllInfoAsync()
        {
            var englishTexts = await _englishTextRepository.GetAllInfoAsync();

            return _mapper.Map<IReadOnlyList<EnglishTextInfoModel>>(englishTexts);
        }

        public async Task<IReadOnlyList<EnglishTextModel>> FindAllByPhrase(string phrase)
        {
            var englishTexts = await _englishTextRepository.FindAllByPhrase(phrase);

            return _mapper.Map<IReadOnlyList<EnglishTextModel>>(englishTexts);
        }

        public async Task<IReadOnlyList<EnglishTextModel>> FindAllByFilters(string[] textTypes, EnglishLevelModel[] englishLevels)
        {
            var englishLevelEntities = _mapper.Map<EnglishLevel[]>(englishLevels);
            var englishTexts = await _englishTextRepository.FindAllByFilters(textTypes, englishLevelEntities);
            if (englishTexts == null)
                return new List<EnglishTextModel>();

            return _mapper.Map<IReadOnlyList<EnglishTextModel>>(englishTexts);
        }

        public async Task<IReadOnlyList<EnglishTextModel>> FindAllByFilters(string phrase, string[] textTypes, EnglishLevelModel[] englishLevels)
        {
            var englishLevelEntities = _mapper.Map<EnglishLevel[]>(englishLevels);
            var englishTexts = await _englishTextRepository.FindAllByFilters(phrase, textTypes, englishLevelEntities);
            if (englishTexts == null)
                return new List<EnglishTextModel>();

            return _mapper.Map<IReadOnlyList<EnglishTextModel>>(englishTexts);
        }

        public async Task<IReadOnlyList<EnglishTextInfoModel>> FindAllInfoByPhrase(string phrase)
        {
            var englishTexts = await _englishTextRepository.FindAllInfoByPhrase(phrase);
            if (englishTexts == null)
                return new List<EnglishTextInfoModel>();

            return _mapper.Map<IReadOnlyList<EnglishTextInfoModel>>(englishTexts);
        }

        public async Task<IReadOnlyList<EnglishTextInfoModel>> FindAllInfoByFilters(string[] textTypes, EnglishLevelModel[] englishLevels)
        {
            var englishLevelsEntities = _mapper.Map<EnglishLevel[]>(englishLevels);
            var englishTexts = await _englishTextRepository.FindAllInfoByFilters(textTypes, englishLevelsEntities);
            if (englishTexts == null)
                return new List<EnglishTextInfoModel>();

            return _mapper.Map<IReadOnlyList<EnglishTextInfoModel>>(englishTexts);
        }

        public async Task<IReadOnlyList<EnglishTextInfoModel>> FindAllInfoByFilters(string phrase, string[] textTypes, EnglishLevelModel[] englishLevels)
        {
            var englishLevelsEntities = _mapper.Map<EnglishLevel[]>(englishLevels);
            var englishTexts = await _englishTextRepository.FindAllInfoByFilters(phrase, textTypes, englishLevelsEntities);
            if (englishTexts == null)
                return new List<EnglishTextInfoModel>();

            return _mapper.Map<IReadOnlyList<EnglishTextInfoModel>>(englishTexts);
        }
    }
}