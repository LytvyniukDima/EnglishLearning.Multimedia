using EnglishLearning.Multimedia.Persistence.Entities;
using EnglishLearning.Multimedia.Persistence.Entities.Video;

namespace EnglishLearning.Multimedia.Persistence.Abstract
{
    public interface IEnglishVideoFiltersRepository
    {
        VideoTypeFilter GetVideoTypeFilter();
        EnglishLevelFilter GetEnglishLevelFilter();
        EnglishVideoFullFilter GetEnglishVideoFullFilter();
    }
}