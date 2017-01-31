using System.Collections.Generic;
using System.Threading.Tasks;
using MemoriesWeb.Core.Model;

namespace MemoriesWeb.Core.Repositories
{
    public interface IMemoryRepository
    {
        Task AddMemory(Memory memory, string connectionString);

        Task UpdateMemory(Memory memory, string connectionString);

        Task DeleteMemory(int id, string connectionString);

        Task<Memory> GetMemory(int id, string connectionString);

        Task<IEnumerable<Memory>> GetAllMemorys(string connectionString);
    }
}
