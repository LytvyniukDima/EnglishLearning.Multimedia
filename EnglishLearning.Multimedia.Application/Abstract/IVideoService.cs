using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Multimedia.Application.Models;
using EnglishLearning.Multimedia.Application.Models.CreateModels;
using EnglishLearning.Multimedia.Application.Models.Enums;
using EnglishLearning.Multimedia.Application.Models.InfoModels;

namespace EnglishLearning.Multimedia.Application.Abstract
{
    public interface IVideoService
    {
        Task CreateAsync(EnglishVideoCreateModel englishTaskCreateModel);
        Task<bool> UpdateAsync(string id, EnglishVideoCreateModel englishTaskModel);
        Task<EnglishVideoModel> GetByIdAsync(string id);
        Task<IReadOnlyList<EnglishVideoModel>> GetAllAsync();
        Task<bool> DeleteByIdAsync(string id);
        Task<bool> DeleteAllAsync();
        
        Task<EnglishVideoInfoModel> GetInfoByIdAsync(string id);
        Task<IReadOnlyList<EnglishVideoInfoModel>> GetAllInfoAsync();
        
        Task<IReadOnlyList<EnglishVideoModel>> FindAllByPhrase(string phrase);
        Task<IReadOnlyList<EnglishVideoModel>> FindAllByFilters(string[] videoTypes, EnglishLevelModel[] englishLevels);
        Task<IReadOnlyList<EnglishVideoModel>> FindAllByFilters(string phrase, string[] videoTypes, EnglishLevelModel[] englishLevels);
        
        Task<IReadOnlyList<EnglishVideoInfoModel>> FindAllInfoByPhrase(string phrase);
        Task<IReadOnlyList<EnglishVideoInfoModel>> FindAllInfoByFilters(string[] videoTypes, EnglishLevelModel[] englishLevels);
        Task<IReadOnlyList<EnglishVideoInfoModel>> FindAllInfoByFilters(string phrase, string[] videoTypes, EnglishLevelModel[] englishLevels);
    }
}