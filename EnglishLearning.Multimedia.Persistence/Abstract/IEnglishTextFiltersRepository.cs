using EnglishLearning.Multimedia.Persistence.Entities;
using EnglishLearning.Multimedia.Persistence.Entities.Text;

namespace EnglishLearning.Multimedia.Persistence.Abstract
{
    public interface IEnglishTextFiltersRepository
    {
        TextTypeFilter GetTextTypeFilter();
        EnglishLevelFilter GetEnglishLevelFilter();
        EnglishTextFullFilter GetEnglishTextFullFilter();
    }
}