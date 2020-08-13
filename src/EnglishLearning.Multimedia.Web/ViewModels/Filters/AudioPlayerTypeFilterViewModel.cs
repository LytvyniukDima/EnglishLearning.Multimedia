using System.Collections.Generic;
using EnglishLearning.Multimedia.Web.ViewModels.Enums;

namespace EnglishLearning.Multimedia.Web.ViewModels.Filters
{
    public class AudioPlayerTypeFilterViewModel
    {
        public Dictionary<AudioPlayerTypeViewModel, int> FilterOptions { get; set; }
    }
}