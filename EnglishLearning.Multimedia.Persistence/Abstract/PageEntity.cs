using System.Collections.Generic;

namespace EnglishLearning.Multimedia.Persistence.Abstract
{
    public class PageEntity<T> where T: IEntity
    {
        public IEnumerable<T> Entities { get; set; }
        public int CountOfPages { get; set; }
    }
}