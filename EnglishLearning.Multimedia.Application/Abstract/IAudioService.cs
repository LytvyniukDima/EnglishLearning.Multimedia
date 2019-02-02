using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Multimedia.Application.Models;
using EnglishLearning.Multimedia.Application.Models.CreateModels;
using EnglishLearning.Multimedia.Application.Models.Enums;
using EnglishLearning.Multimedia.Application.Models.InfoModels;

namespace EnglishLearning.Multimedia.Application.Abstract
{
    public interface IAudioService
    {
        Task CreateAsync(EnglishAudioCreateModel englishAudioCreateModel);
        Task<bool> UpdateAsync(string id, EnglishAudioModel englishAudioModel);
        Task<EnglishAudioModel> GetByIdAsync(string id);
        Task<IReadOnlyList<EnglishAudioModel>> GetAllAsync();
        Task<bool> DeleteByIdAsync(string id);
        Task<bool> DeleteAllAsync();
        
        Task<EnglishAudioInfoModel> GetInfoByIdAsync(string id);
        Task<IReadOnlyList<EnglishAudioInfoModel>> GetInfoAllAsync();
        
        Task<IReadOnlyList<EnglishAudioModel>> FindAllByPhrase(string phrase);
        Task<IReadOnlyList<EnglishAudioModel>> FindAllByFilters(string[] audioTypes, EnglishLevelModel[] englishLevels);
        Task<IReadOnlyList<EnglishAudioModel>> FindAllByFilters(string phrase, string[] audioTypes, EnglishLevelModel[] englishLevels);
        
        Task<IReadOnlyList<EnglishAudioInfoModel>> FindAllInfoByPhrase(string phrase);
        Task<IReadOnlyList<EnglishAudioInfoModel>> FindAllInfoByFilters(string[] audioTypes, EnglishLevelModel[] englishLevels);
        Task<IReadOnlyList<EnglishAudioInfoModel>> FindAllInfoByFilters(string phrase, string[] audioTypes, EnglishLevelModel[] englishLevels);
    }
}
