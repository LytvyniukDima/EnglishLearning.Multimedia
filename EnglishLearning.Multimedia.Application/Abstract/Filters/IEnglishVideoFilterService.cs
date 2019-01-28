using EnglishLearning.Multimedia.Application.Models.Filters;

namespace EnglishLearning.Multimedia.Application.Abstract.Filters
{
    public interface IEnglishVideoFilterService
    {
        VideoTypeFilterModel GetVideoTypeFilter();
        EnglishLevelFilterModel GetEnglishLevelFilter();
        EnglishVideoFullFilterModel GetEnglishVideoFullFilter();
    }
}