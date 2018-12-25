using EnglishLearning.Multimedia.Persistence.Entities.Audio;
using EnglishLearning.Utilities.Persistence.Interfaces;

namespace EnglishLearning.Multimedia.Persistence.Abstract
{
    public interface IEnglishAudioRepository : IBaseWithInfoModelRepository<EnglishAudio, EnglishAudioInfo>
    {
        
    }
}