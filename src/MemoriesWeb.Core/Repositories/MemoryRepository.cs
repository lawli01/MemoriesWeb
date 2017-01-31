using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MemoriesWeb.Core.Common;
using MemoriesWeb.Core.Model;
using Microsoft.Extensions.Options;
using Npgsql;

namespace MemoriesWeb.Core.Repositories
{
    public class MemoryRepository : IRepository<Memory>
    {
        private readonly string _connectionString;
        public MemoryRepository(IOptions<MySettings> config)
        {
            _connectionString = config.Value.PostgresSqlConnectionString;
        }

        internal IDbConnection Connection => new NpgsqlConnection(_connectionString);

        public async Task<int> AddAsync(Memory memory)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return await dbConnection.ExecuteAsync("INSERT INTO dbo.Memories VALUES(@Name,@Description,@Rating,@UploadDate,@Image,@UserId)", memory);
            }
        }

        public async Task<IEnumerable<Memory>> FindAllAsync()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return await dbConnection.QueryAsync<Memory>("SELECT * FROM dbo.Memories");
            }
        }

        public async Task<Memory> FindByIdAsync(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return (await dbConnection.QueryAsync<Memory>("SELECT * FROM dbo.Memories WHERE id = @Id", new {Id = id})).FirstOrDefault();
            }
        }

        public async Task<int> RemoveAsync(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return await dbConnection.ExecuteAsync("DELETE FROM dbo.Memories WHERE Id=@Id", new { Id = id });
            }
        }

        public async Task<int> UpdateAsync(Memory memory)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return await dbConnection.ExecuteAsync("UPDATE dbo.Memories SET name=@Name,description=@Description,rating=@Rating,uploadDate=@UploadDate,image=@Image,userid=@UserId WHERE id = @Id", memory);
            }
        }
    }
}
