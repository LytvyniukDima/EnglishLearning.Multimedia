using System.Collections.Generic;
using EnglishLearning.Multimedia.Web.ViewModels.Enums;

namespace EnglishLearning.Multimedia.Web.ViewModels.Filters
{
    public class EnglishLevelFilterViewModel
    {
        public Dictionary<EnglishLevelViewModel, int> FilterOptions { get; set; }
    }
}