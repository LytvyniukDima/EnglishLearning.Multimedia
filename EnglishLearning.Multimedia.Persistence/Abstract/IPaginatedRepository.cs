using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EnglishLearning.Multimedia.Persistence.Abstract
{
    public interface IPaginatedRepository<T> where T: IEntity
    {
        Task<PageEntity<T>> GetPagenatedAsync(string lastId, int countPerPage);
        Task<PageEntity<T>> FindPagenatedAsync(Expression<Func<T, bool>> filter, string lastId, int countPerPage);
    }
}