using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemoriesWeb.Core.Model;

namespace MemoriesWeb.Core.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<int> AddAsync(T item);
        Task<int> RemoveAsync(int id);
        Task<int> UpdateAsync(T item);
        Task<T> FindByIdAsync(int id);
        Task<IEnumerable<T>> FindAllAsync();
    }
}
