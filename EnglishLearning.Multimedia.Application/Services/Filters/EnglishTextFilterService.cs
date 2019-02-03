using AutoMapper;
using EnglishLearning.Multimedia.Application.Abstract.Filters;
using EnglishLearning.Multimedia.Application.Infrastructure;
using EnglishLearning.Multimedia.Application.Models.Filters;
using EnglishLearning.Multimedia.Persistence.Abstract;
using EnglishLearning.Multimedia.Persistence.Entities;
using EnglishLearning.Multimedia.Persistence.Entities.Text;

namespace EnglishLearning.Multimedia.Application.Services.Filters
{
    public class EnglishTextFilterService : IEnglishTextFilterService
    {
        private readonly IEnglishTextFiltersRepository _englishTextFiltersRepository;
        private readonly IMapper _mapper;

        public EnglishTextFilterService(IEnglishTextFiltersRepository englishTextFiltersRepository, ApplicationMapper applicationMapper)
        {
            _englishTextFiltersRepository = englishTextFiltersRepository;
            _mapper = applicationMapper.Mapper;
        }
        
        public TextTypeFilterModel GetTextTypeFilter()
        {
            TextTypeFilter textTypeFilter = _englishTextFiltersRepository.GetTextTypeFilter();

            return _mapper.Map<TextTypeFilterModel>(textTypeFilter);
        }

        public EnglishLevelFilterModel GetEnglishLevelFilter()
        {
            EnglishLevelFilter englishLevelFilter = _englishTextFiltersRepository.GetEnglishLevelFilter();

            return _mapper.Map<EnglishLevelFilterModel>(englishLevelFilter);
        }

        public EnglishTextFullFilterModel GetEnglishTextFullFilter()
        {
            EnglishTextFullFilter englishTextFullFilter = _englishTextFiltersRepository.GetEnglishTextFullFilter();

            return _mapper.Map<EnglishTextFullFilterModel>(englishTextFullFilter);
        }
    }
}