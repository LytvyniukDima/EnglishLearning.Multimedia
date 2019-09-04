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
        Task CreateAsync(EnglishVideoCreateModel englishTextCreateModel);
        Task<bool> UpdateAsync(string id, EnglishVideoModel englishTextModel);
        Task<EnglishVideoModel> GetByIdAsync(string id);
        Task<IReadOnlyList<EnglishVideoModel>> GetAllAsync();
        Task<bool> DeleteByIdAsync(string id);
        Task<bool> DeleteAllAsync();
        
        Task<EnglishVideoInfoModel> GetInfoByIdAsync(string id);
        Task<IReadOnlyList<EnglishVideoInfoModel>> GetAllInfoAsync();
        
        Task<IReadOnlyList<EnglishVideoModel>> FindAllByFilters(string phrase, string[] videoTypes, EnglishLevelModel[] englishLevels);
        
        Task<IReadOnlyList<EnglishVideoInfoModel>> FindAllInfoByFilters(string phrase, string[] videoTypes, EnglishLevelModel[] englishLevels);
    }
}