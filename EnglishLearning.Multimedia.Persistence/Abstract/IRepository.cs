using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EnglishLearning.Multimedia.Persistence.Abstract
{
    public interface IRepository<T> where T : IEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> FindAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> filter);
        Task AddAsync(T item);
        Task<bool> DeleteAsync(Expression<Func<T, bool>> filter);
        Task<bool> UpdateAsync(string id, T item);
        Task<bool> DeleteAllAsync();
        Task<PageEntity<T>> GetPagenatedAsync(string lastId, int countPerPage);
        Task<PageEntity<T>> FindPagenatedAsync(Expression<Func<T, bool>> filter, string lastId, int countPerPage);
    }
}