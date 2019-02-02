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
using EnglishLearning.Multimedia.Persistence.Entities.Audio;

namespace EnglishLearning.Multimedia.Application.Services
{
    public class AudioService : IAudioService
    {
        private readonly IEnglishAudioRepository _englishAudioRepository;
        private readonly IMapper _mapper;
        
        public AudioService(IEnglishAudioRepository englishAudioRepository, ApplicationMapper applicationMapper)
        {
            _englishAudioRepository = englishAudioRepository;
            _mapper = applicationMapper.Mapper;
        }
        
        public async Task CreateAsync(EnglishAudioCreateModel englishAudioCreateModel)
        {
            var englishAudio = _mapper.Map<EnglishAudio>(englishAudioCreateModel);
            
            await _englishAudioRepository.AddAsync(englishAudio);
        }

        public async Task<bool> UpdateAsync(string id, EnglishAudioModel englishAudioModel)
        {
            var englishAudio = _mapper.Map<EnglishAudio>(englishAudioModel);

            return await _englishAudioRepository.UpdateAsync(id, englishAudio);
        }

        public async Task<EnglishAudioModel> GetByIdAsync(string id)
        {
            var englishAudio = await _englishAudioRepository.FindAsync(x => x.Id == id);
            // TODO: Throw NotFoundException
            if (englishAudio == null)
                return null;
            
            return _mapper.Map<EnglishAudioModel>(englishAudio);
        }

        public async Task<IReadOnlyList<EnglishAudioModel>> GetAllAsync()
        {
            var englishAudios = await _englishAudioRepository.GetAllAsync();

            return _mapper.Map<IReadOnlyList<EnglishAudioModel>>(englishAudios);
        }

        public async Task<bool> DeleteByIdAsync(string id)
        {
            return await _englishAudioRepository.DeleteAsync(x => x.Id == id);
        }

        public async Task<bool> DeleteAllAsync()
        {
            return await _englishAudioRepository.DeleteAllAsync();
        }

        public async Task<EnglishAudioInfoModel> GetInfoByIdAsync(string id)
        {
            var englishAudio = await _englishAudioRepository.FindAsync(x => x.Id == id);
            if (englishAudio == null)
                return null;

            return _mapper.Map<EnglishAudioInfoModel>(englishAudio);
        }

        public async Task<IReadOnlyList<EnglishAudioInfoModel>> GetInfoAllAsync()
        {
            var englishInfoAudios = await _englishAudioRepository.GetAllInfoAsync();

            return _mapper.Map<IReadOnlyList<EnglishAudioInfoModel>>(englishInfoAudios);
        }

        public async Task<IReadOnlyList<EnglishAudioModel>> FindAllByPhrase(string phrase)
        {
            var englishAudios = await _englishAudioRepository.FindAllByPhrase(phrase);
            if (englishAudios == null)
                return new List<EnglishAudioModel>();

            return _mapper.Map<IReadOnlyList<EnglishAudioModel>>(englishAudios);
        }

        public async Task<IReadOnlyList<EnglishAudioModel>> FindAllByFilters(string[] audioTypes, EnglishLevelModel[] englishLevels)
        {
            var englishLevelsEntities = _mapper.Map<EnglishLevel[]>(englishLevels);
            var englishAudios = await _englishAudioRepository.FindAllByFilters(audioTypes, englishLevelsEntities);
            if (englishAudios == null)
                return new List<EnglishAudioModel>();

            return _mapper.Map<IReadOnlyList<EnglishAudioModel>>(englishAudios);
        }

        public async Task<IReadOnlyList<EnglishAudioModel>> FindAllByFilters(string phrase, string[] audioTypes, EnglishLevelModel[] englishLevels)
        {
            var englishLevelsEntities = _mapper.Map<EnglishLevel[]>(englishLevels);
            var englishAudios = await _englishAudioRepository.FindAllByFilters(phrase, audioTypes, englishLevelsEntities);
            if (englishAudios == null)
                return new List<EnglishAudioModel>();

            return _mapper.Map<IReadOnlyList<EnglishAudioModel>>(englishAudios);
        }

        public async Task<IReadOnlyList<EnglishAudioInfoModel>> FindAllInfoByPhrase(string phrase)
        {
            var englishInfoAudios = await _englishAudioRepository.FindAllInfoByPhrase(phrase);
            if (englishInfoAudios == null)
                return new List<EnglishAudioInfoModel>();

            return _mapper.Map<IReadOnlyList<EnglishAudioInfoModel>>(englishInfoAudios);
        }

        public async Task<IReadOnlyList<EnglishAudioInfoModel>> FindAllInfoByFilters(string[] audioTypes, EnglishLevelModel[] englishLevels)
        {
            var englishLevelsEntities = _mapper.Map<EnglishLevel[]>(englishLevels);
            var englishAudios = await _englishAudioRepository.FindAllInfoByFilters(audioTypes, englishLevelsEntities);
            if (englishAudios == null)
                return new List<EnglishAudioInfoModel>();

            return _mapper.Map<IReadOnlyList<EnglishAudioInfoModel>>(englishAudios);
        }

        public async Task<IReadOnlyList<EnglishAudioInfoModel>> FindAllInfoByFilters(string phrase, string[] audioTypes, EnglishLevelModel[] englishLevels)
        {
            var englishLevelsEntities = _mapper.Map<EnglishLevel[]>(englishLevels);
            var englishAudios = await _englishAudioRepository.FindAllInfoByFilters(phrase, audioTypes, englishLevelsEntities);
            if (englishAudios == null)
                return new List<EnglishAudioInfoModel>();

            return _mapper.Map<IReadOnlyList<EnglishAudioInfoModel>>(englishAudios);
        }
    }
}
