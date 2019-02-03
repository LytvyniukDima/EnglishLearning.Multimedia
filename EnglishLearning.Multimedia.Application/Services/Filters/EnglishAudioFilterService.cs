using AutoMapper;
using EnglishLearning.Multimedia.Application.Abstract.Filters;
using EnglishLearning.Multimedia.Application.Infrastructure;
using EnglishLearning.Multimedia.Application.Models.Filters;
using EnglishLearning.Multimedia.Persistence.Abstract;
using EnglishLearning.Multimedia.Persistence.Entities;
using EnglishLearning.Multimedia.Persistence.Entities.Audio;

namespace EnglishLearning.Multimedia.Application.Services.Filters
{
    public class EnglishAudioFilterService : IEnglishAudioFilterService
    {
        private readonly IEnglishAudioFiltersRepository _englishAudioFiltersRepository;
        private readonly IMapper _mapper;
        public EnglishAudioFilterService(IEnglishAudioFiltersRepository englishAudioFiltersRepository, ApplicationMapper applicationMapper)
        {
            _englishAudioFiltersRepository = englishAudioFiltersRepository;
            _mapper = applicationMapper.Mapper;
        }
        
        public AudioPlayerTypeFilterModel GetAudioPlayerTypeFilter()
        {
            AudioPlayerTypeFilter audioPlayerType = _englishAudioFiltersRepository.GetAudioPlayerTypeFilter();

            return _mapper.Map<AudioPlayerTypeFilterModel>(audioPlayerType);
        }

        public AudioTypeFilterModel GetAudioTypeFilter()
        {
            AudioTypeFilter audioTypeFilter = _englishAudioFiltersRepository.GetAudioTypeFilter();

            return _mapper.Map<AudioTypeFilterModel>(audioTypeFilter);
        }

        public EnglishLevelFilterModel GetEnglishLevelFilter()
        {
            EnglishLevelFilter englishLevelFilter = _englishAudioFiltersRepository.GetEnglishLevelFilter();

            return _mapper.Map<EnglishLevelFilterModel>(englishLevelFilter);
        }

        public EnglishAudioFullFilterModel GetEnglishAudioFullFilter()
        {
            EnglishAudioFullFilter englishAudioFullFilter = _englishAudioFiltersRepository.GetEnglishAudioFullFilter();

            return _mapper.Map<EnglishAudioFullFilterModel>(englishAudioFullFilter);
        }
    }
}
