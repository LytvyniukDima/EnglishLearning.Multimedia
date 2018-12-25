using System.Collections.Generic;
using EnglishLearning.Utilities.Persistence.Mongo.Interfaces;

namespace EnglishLearning.Multimedia.Persistence.Abstract
{
    public class PageEntity<T> where T: IStringIdEntity
    {
        public IEnumerable<T> Entities { get; set; }
        public int CountOfPages { get; set; }
    }
}