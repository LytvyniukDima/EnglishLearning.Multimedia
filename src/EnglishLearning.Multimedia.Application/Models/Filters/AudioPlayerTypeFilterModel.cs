using System.Collections.Generic;
using EnglishLearning.Multimedia.Application.Models.Enums;

namespace EnglishLearning.Multimedia.Application.Models.Filters
{
    public class AudioPlayerTypeFilterModel
    {
        public Dictionary<AudioPlayerTypeModel, int> FilterOptions { get; set; }
    }
}