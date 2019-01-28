using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Multimedia.Application.Models;
using EnglishLearning.Multimedia.Application.Models.CreateModels;
using EnglishLearning.Multimedia.Application.Models.Enums;
using EnglishLearning.Multimedia.Application.Models.InfoModels;

namespace EnglishLearning.Multimedia.Application.Abstract
{
    public interface ITextService
    {
        Task CreateAsync(EnglishTextCreateModel englishTaskCreateModel);
        Task<bool> UpdateAsync(string id, EnglishTextCreateModel englishTaskModel);
        Task<EnglishTextModel> GetByIdAsync(string id);
        Task<IReadOnlyList<EnglishTextModel>> GetAllAsync();
        Task<bool> DeleteByIdAsync(string id);
        Task<bool> DeleteAllAsync();
        
        Task<EnglishTextInfoModel> GetInfoByIdAsync(string id);
        Task<IReadOnlyList<EnglishTextInfoModel>> GetAllInfoAsync();
        
        Task<IReadOnlyList<EnglishTextModel>> FindAllByPhrase(string phrase);
        Task<IReadOnlyList<EnglishTextModel>> FindAllByFilters(string[] textTypes, EnglishLevelModel[] englishLevels);
        Task<IReadOnlyList<EnglishTextModel>> FindAllByFilters(string phrase, string[] textTypes, EnglishLevelModel[] englishLevels);
        
        Task<IReadOnlyList<EnglishTextInfoModel>> FindAllInfoByPhrase(string phrase);
        Task<IReadOnlyList<EnglishTextInfoModel>> FindAllInfoByFilters(string[] textTypes, EnglishLevelModel[] englishLevels);
        Task<IReadOnlyList<EnglishTextInfoModel>> FindAllInfoByFilters(string phrase, string[] textTypes, EnglishLevelModel[] englishLevels);
    }
}