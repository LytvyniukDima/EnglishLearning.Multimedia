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
using EnglishLearning.Multimedia.Persistence.Entities.Video;

namespace EnglishLearning.Multimedia.Application.Services
{
    public class VideoService : IVideoService
    {
        private readonly IEnglishVideoRepository _englishVideoRepository;
        private readonly IMapper _mapper;
        
        public VideoService(IEnglishVideoRepository englishVideoRepository, ApplicationMapper applicationMapper)
        {
            _englishVideoRepository = englishVideoRepository;
            _mapper = applicationMapper.Mapper;
        }
        
        public async Task CreateAsync(EnglishVideoCreateModel englishVideoCreateModel)
        {
            var englishVideo = _mapper.Map<EnglishVideo>(englishVideoCreateModel);

            await _englishVideoRepository.AddAsync(englishVideo);
        }

        public async Task<bool> UpdateAsync(string id, EnglishVideoModel englishVideoModel)
        {
            var englishVideo = _mapper.Map<EnglishVideo>(englishVideoModel);
            englishVideo.Id = id;
            
            return await _englishVideoRepository.UpdateAsync(englishVideo);
        }

        public async Task<EnglishVideoModel> GetByIdAsync(string id)
        {
            var englishVideo = await _englishVideoRepository.FindAsync(x => x.Id == id);

            return _mapper.Map<EnglishVideoModel>(englishVideo);
        }

        public async Task<IReadOnlyList<EnglishVideoModel>> GetAllAsync()
        {
            var englishVideos = await _englishVideoRepository.GetAllAsync();

            return _mapper.Map<IReadOnlyList<EnglishVideoModel>>(englishVideos);
        }

        public async Task<bool> DeleteByIdAsync(string id)
        {
            return await _englishVideoRepository.DeleteAsync(x => x.Id == id);
        }

        public async Task<bool> DeleteAllAsync()
        {
            return await _englishVideoRepository.DeleteAllAsync();
        }

        public async Task<EnglishVideoInfoModel> GetInfoByIdAsync(string id)
        {
            var englishVideo = await _englishVideoRepository.FindAsync(x => x.Id == id);

            return _mapper.Map<EnglishVideoInfoModel>(englishVideo);
        }

        public async Task<IReadOnlyList<EnglishVideoInfoModel>> GetAllInfoAsync()
        {
            var englishVideos = await _englishVideoRepository.GetAllInfoAsync();

            return _mapper.Map<IReadOnlyList<EnglishVideoInfoModel>>(englishVideos);
        }

        public async Task<IReadOnlyList<EnglishVideoModel>> FindAllByFilters(string phrase, string[] videoTypes, EnglishLevelModel[] englishLevels)
        {
            var englishLevelEntities = _mapper.Map<EnglishLevel[]>(englishLevels);
            var englishVideos = await _englishVideoRepository.FindAllByFilters(phrase, videoTypes, englishLevelEntities);
            if (englishVideos == null)
            {
                return new List<EnglishVideoModel>();
            }

            return _mapper.Map<IReadOnlyList<EnglishVideoModel>>(englishVideos);
        }

        public async Task<IReadOnlyList<EnglishVideoInfoModel>> FindAllInfoByFilters(string phrase, string[] videoTypes, EnglishLevelModel[] englishLevels)
        {
            var englishLevelEntities = _mapper.Map<EnglishLevel[]>(englishLevels);
            var englishVideos = await _englishVideoRepository.FindAllInfoByFilters(phrase, videoTypes, englishLevelEntities);
            if (englishVideos == null)
            {
                return new List<EnglishVideoInfoModel>();
            }

            return _mapper.Map<IReadOnlyList<EnglishVideoInfoModel>>(englishVideos);
        }
    }
}