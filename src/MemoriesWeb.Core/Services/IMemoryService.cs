using System.Collections.Generic;
using System.Threading.Tasks;
using MemoriesWeb.Core.Model;

namespace MemoriesWeb.Core.Services
{
    public interface IMemoryService
    {
        Task<int> AddMemory(Memory memory);
        Task<int> RemoveMemory(int id);
        Task<Memory> FindMemoryById(int id);
        Task<int> UpdateMemory(Memory item);
        Task<IEnumerable<Memory>> GetAllMemories();
    }
}
