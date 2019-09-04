using AutoMapper;
using EnglishLearning.Multimedia.Application.Abstract.Filters;
using EnglishLearning.Multimedia.Application.Infrastructure;
using EnglishLearning.Multimedia.Application.Models.Filters;
using EnglishLearning.Multimedia.Persistence.Abstract;
using EnglishLearning.Multimedia.Persistence.Entities;
using EnglishLearning.Multimedia.Persistence.Entities.Video;

namespace EnglishLearning.Multimedia.Application.Services.Filters
{
    public class EnglishVideoFilterService : IEnglishVideoFilterService
    {
        private readonly IEnglishVideoFiltersRepository _englishVideoFiltersRepository;
        private readonly IMapper _mapper;

        public EnglishVideoFilterService(IEnglishVideoFiltersRepository englishVideoFiltersRepository, ApplicationMapper applicationMapper)
        {
            _englishVideoFiltersRepository = englishVideoFiltersRepository;
            _mapper = applicationMapper.Mapper;
        }
        
        public VideoTypeFilterModel GetVideoTypeFilter()
        {
            VideoTypeFilter videoTypeFilter = _englishVideoFiltersRepository.GetVideoTypeFilter();

            return _mapper.Map<VideoTypeFilterModel>(videoTypeFilter);
        }

        public EnglishLevelFilterModel GetEnglishLevelFilter()
        {
            EnglishLevelFilter englishLevelFilter = _englishVideoFiltersRepository.GetEnglishLevelFilter();

            return _mapper.Map<EnglishLevelFilterModel>(englishLevelFilter);
        }

        public EnglishVideoFullFilterModel GetEnglishVideoFullFilter()
        {
            EnglishVideoFullFilter englishVideoFullFilter = _englishVideoFiltersRepository.GetEnglishVideoFullFilter();

            return _mapper.Map<EnglishVideoFullFilterModel>(englishVideoFullFilter);
        }
    }
}