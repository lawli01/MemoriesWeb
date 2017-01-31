using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemoriesWeb.Core.Model;
using MemoriesWeb.Core.Repositories;

namespace MemoriesWeb.Core.Services
{
    public class MemoryService : IMemoryService
    {
        private readonly IRepository<Memory> _memoryRepoistory;

        public MemoryService(IRepository<Memory> memoryRepository)
        {
            _memoryRepoistory = memoryRepository;
        }

        public async Task<int> AddMemory(Memory memory)
        {
           return await _memoryRepoistory.AddAsync(memory);
        }

        public async Task<int> RemoveMemory(int id)
        {
           return await _memoryRepoistory.RemoveAsync(id);
        }

        public async Task<Memory> FindMemoryById(int id)
        {
            return await _memoryRepoistory.FindByIdAsync(id);
        }

        public async Task<int> UpdateMemory(Memory memory)
        {
           return await _memoryRepoistory.UpdateAsync(memory);
        }

        public async Task<IEnumerable<Memory>> GetAllMemories()
        {
            return await _memoryRepoistory.FindAllAsync();
        }
    }
}
