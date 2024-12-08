using FWF.Core.Domain.Interfaces;
using FWF.Core.Helpers.QueryHelpers;

namespace FWF.Core.Domain.RepositoryInterfaces
{
    public interface IRepository<T> where T : class, IDomainClass
    {
        Task<int> GetCountAsync();
        Task<bool> AnyAsync();
        Task<T> AddAsync(T item);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetItemsAsync(PagingParameters pagingParameters, SortInfo sortInfo);
    }
}
