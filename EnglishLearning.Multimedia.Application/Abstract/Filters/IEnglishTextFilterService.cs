using EnglishLearning.Multimedia.Application.Models.Filters;

namespace EnglishLearning.Multimedia.Application.Abstract.Filters
{
    public interface IEnglishTextFilterService
    {
        TextTypeFilterModel GetTextTypeFilter();
        EnglishLevelFilterModel GetEnglishLevelFilter();
        EnglishTextFullFilterModel GetEnglishTextFullFilter();
    }
}