using EnglishLearning.Multimedia.Persistence.Entities.Video;
using EnglishLearning.Utilities.Persistence.Interfaces;

namespace EnglishLearning.Multimedia.Persistence.Abstract
{
    public interface IEnglishVideoRepository : IBaseWithInfoModelRepository<EnglishVideo, EnglishVideoInfo>
    {
        
    }
}