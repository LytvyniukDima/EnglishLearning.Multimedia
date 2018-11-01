using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EnglishLearning.Multimedia.Persistence.Abstract;
using MongoDB.Bson;
using MongoDB.Driver;

namespace EnglishLearning.Multimedia.Persistence.Repositories
{
    public abstract class BaseMongoDbRepository<T, TInfo> : IRepository<T, TInfo> where T : IEntity where TInfo : IEntity
    {
        protected readonly IMultimediaDbContext _dbContext;
        protected readonly IMongoCollection<T> _collection;
        
        protected abstract ProjectionDefinition<T, TInfo> TInfoProjection { get; }
        
        protected BaseMongoDbRepository(IMultimediaDbContext dbContext, string collectionName)
        {
            _dbContext = dbContext;
            _collection = dbContext.GetCollection<T>(collectionName);
        }
        
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> filter)
        {
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> filter)
        {
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAllAsync(FilterDefinition<T> filter)
        {
            return await _collection.Find(filter).ToListAsync();
        }

        public virtual async Task AddAsync(T item)
        {
            await _collection.InsertOneAsync(item);
        }

        public virtual async Task<bool> DeleteAsync(Expression<Func<T, bool>> filter)
        {
            DeleteResult actionResult = await _collection.DeleteManyAsync(filter);
            return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
        }

        public async Task<bool> DeleteAsync(FilterDefinition<T> filter)
        {
            DeleteResult actionResult = await _collection.DeleteManyAsync(filter);
            return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
        }

        public virtual async Task<bool> UpdateAsync(string id, T item)
        {
            var actionResult = await _collection.ReplaceOneAsync(x => x.Id == id, item);
            return actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;
        }

        public virtual async Task<bool> DeleteAllAsync()
        {
            DeleteResult actionResult = await _collection.DeleteManyAsync(_ => true);
            return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
        }
        
        public virtual async Task<PageEntity<T>> GetPagenatedAsync(string lastId, int countPerPage)
        {
            var page = new PageEntity<T>();
            
            if (String.IsNullOrEmpty(lastId))
            {
                page.Entities = await _collection.Find(_ => true).Limit(countPerPage).ToListAsync();
                page.CountOfPages = (int)((await _collection.CountDocumentsAsync(new BsonDocument())) / countPerPage);
            }
            else
            {
                var idFilter = new BsonDocument("Id", new BsonDocument("$gt", lastId));
                page.Entities = await _collection.Find(idFilter).Limit(countPerPage).ToListAsync();
            }

            return page;
        }

        public virtual async Task<PageEntity<T>> FindPagenatedAsync(Expression<Func<T, bool>> filter, string lastId, int countPerPage)
        {
            var page = new PageEntity<T>();

            if (String.IsNullOrEmpty(lastId))
            {
                page.Entities = await _collection.Find(filter).Limit(countPerPage).ToListAsync();
                page.CountOfPages = (int) (_collection.Find(filter).Count() / countPerPage);
            }
            else
            {   
                var buildedFilter = Builders<T>.Filter;
                var mongoFilter = buildedFilter.Where(filter) & buildedFilter.Gt("Id", lastId);
                
                page.Entities = await _collection.Find(mongoFilter).Limit(countPerPage).ToListAsync();
            }

            return page;
        }

        public async Task<PageEntity<T>> FindPagenatedAsync(FilterDefinition<T> filter, string lastId, int countPerPage)
        {
            var page = new PageEntity<T>();

            if (String.IsNullOrEmpty(lastId))
            {
                page.Entities = await _collection.Find(filter).Limit(countPerPage).ToListAsync();
                page.CountOfPages = (int) (_collection.Find(filter).CountDocuments() / countPerPage);
            }
            else
            {   
                var buildedFilter = Builders<T>.Filter;
                var mongoFilter = filter & buildedFilter.Gt("Id", lastId);
                
                page.Entities = await _collection.Find(mongoFilter).Limit(countPerPage).ToListAsync();
            }

            return page;
        }

        public async Task<IEnumerable<TInfo>> GetAllInfoAsync()
        {
            return await _collection
                .Find(new BsonDocument())
                .Project(TInfoProjection)
                .ToListAsync();
        }

        public async Task<IEnumerable<TInfo>> FindAllInfoAsync(FilterDefinition<T> filter)
        {
            return await _collection
                .Find(filter)
                .Project(TInfoProjection)
                .ToListAsync();
        }

        public async Task<PageEntity<TInfo>> GetPagenatedInfoAsync(string lastId, int countPerPage)
        {
            var page = new PageEntity<TInfo>();
            
            if (String.IsNullOrEmpty(lastId))
            {
                page.Entities = await _collection
                    .Find(new BsonDocument())
                    .Limit(countPerPage)
                    .Project(TInfoProjection)
                    .ToListAsync();
                page.CountOfPages = (int)((await _collection.CountDocumentsAsync(new BsonDocument())) / countPerPage);
            }
            else
            {
                var idFilter = new BsonDocument("Id", new BsonDocument("$gt", lastId));
                page.Entities = await _collection
                    .Find(idFilter)
                    .Limit(countPerPage)
                    .Project(TInfoProjection)
                    .ToListAsync();
            }

            return page;
        }

        public async Task<PageEntity<TInfo>> FindPagenatedInfoAsync(FilterDefinition<T> filter, string lastId, int countPerPage)
        {
            var page = new PageEntity<TInfo>();

            if (String.IsNullOrEmpty(lastId))
            {
                page.Entities = await _collection
                    .Find(filter)
                    .Limit(countPerPage)
                    .Project(TInfoProjection)
                    .ToListAsync();
                page.CountOfPages = (int) (_collection.Find(filter).CountDocuments() / countPerPage);
            }
            else
            {   
                var buildedFilter = Builders<T>.Filter;
                var mongoFilter = filter & buildedFilter.Gt("Id", lastId);
                
                page.Entities = await _collection
                    .Find(mongoFilter)
                    .Limit(countPerPage)
                    .Project(TInfoProjection)
                    .ToListAsync();
            }

            return page;
        }
    }
}
