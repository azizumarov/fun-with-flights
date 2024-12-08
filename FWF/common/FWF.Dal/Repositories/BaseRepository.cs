using AutoMapper;
using FWF.Core.Domain.Interfaces;
using FWF.Core.Domain.RepositoryInterfaces;
using FWF.Core.Helpers.QueryHelpers;
using FWF.Dal.QueryableEstenstions;
using FWF.Dal.SqlContext;
using Microsoft.EntityFrameworkCore;

namespace FWF.Dal.Repositories
{
    public class BaseRepository<TDomain, TEntity>(IFwfContextFactory dbFactory, IMapper mapper) : IRepository<TDomain>
        where TDomain : class, IDomainClass
        where TEntity : class, new()
    {
        public Task<TDomain> AddAsync(TDomain item)
        {
            var entity = new TEntity();
            mapper.Map(item, entity);
            var dbContext = dbFactory.CreateContext();
            dbContext.Add(entity);
            dbContext.SaveChanges();
            return Task.FromResult(item);
        }

        public async Task<bool> AnyAsync()
        {
            var dbContext = dbFactory.CreateContext();
            return await dbContext.Set<TEntity>().AnyAsync();
        }

        public virtual Task<List<TDomain>> GetAllAsync()
        {
            return dbFactory.CreateContext()
                .Set<TEntity>()
                .Select(item => mapper.Map<TDomain>(item))
                .ToListAsync();
        }

        public async virtual Task<int> GetCountAsync()
        {
            return await dbFactory.CreateContext().Set<TEntity>()
                .CountAsync();
        }

        public Task<List<TDomain>> GetItemsAsync(PagingParameters pagingParameters, SortInfo sortInfo)
        {
            return dbFactory.CreateContext()
                .Set<TEntity>()
                .ApplyPagingAndSortingAnyObject(pagingParameters, sortInfo)
                .Select(item => mapper.Map<TDomain>(item))
                .ToListAsync();
        }
    }
}
