using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EnglishLearning.Multimedia.Persistence.Abstract
{
    public interface IMongoDbPaginatedRepository<T> where T: IEntity
    {
        Task<IEnumerable<PageEntity<T>>> GetPagenatedAsync(string lastId, int countPerPage);
        Task<IEnumerable<PageEntity<T>>> FindPagenatedAsync(Expression<Func<T, bool>> filter, string lastId, int countPerPage);
    }
}