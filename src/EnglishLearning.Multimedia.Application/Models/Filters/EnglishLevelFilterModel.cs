using System.Collections.Generic;
using EnglishLearning.Multimedia.Application.Models.Enums;

namespace EnglishLearning.Multimedia.Application.Models.Filters
{
    public class EnglishLevelFilterModel
    {
        public Dictionary<EnglishLevelModel, int> FilterOptions { get; set; }
    }
}