using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace EnglishLearning.Multimedia.Persistence.Abstract
{
    public interface IRepository<T, TInfo> where T : IEntity where TInfo: IEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> FindAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> FindAllAsync(FilterDefinition<T> filter);
        Task AddAsync(T item);
        Task<bool> DeleteAsync(Expression<Func<T, bool>> filter);
        Task<bool> DeleteAsync(FilterDefinition<T> filter);
        Task<bool> UpdateAsync(string id, T item);
        Task<bool> DeleteAllAsync();
        Task<PageEntity<T>> GetPagenatedAsync(string lastId, int countPerPage);
        Task<PageEntity<T>> FindPagenatedAsync(Expression<Func<T, bool>> filter, string lastId, int countPerPage);
        Task<PageEntity<T>> FindPagenatedAsync(FilterDefinition<T> filter, string lastId, int countPerPage);
        
        Task<IEnumerable<TInfo>> GetAllInfoAsync();
        Task<IEnumerable<TInfo>> FindAllInfoAsync(FilterDefinition<T> filter);
        Task<PageEntity<TInfo>> GetPagenatedInfoAsync(string lastId, int countPerPage);
        Task<PageEntity<TInfo>> FindPagenatedInfoAsync(FilterDefinition<T> filter, string lastId, int countPerPage); 
    }
}
