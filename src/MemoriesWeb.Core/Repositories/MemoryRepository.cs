using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MemoriesWeb.Core.Model;
using Npgsql;

namespace MemoriesWeb.Core.Repositories
{
    public class MemoryRepository : IRepository<Memory>
    {
        private readonly string _connectionString;
        public MemoryRepository()
        {
            _connectionString = "Host=127.0.0.1;Username=postgres;Password=puppylile;Database=MemoriesDb";
        }

        internal IDbConnection Connection => new NpgsqlConnection(_connectionString);

        public async Task<int> AddAsync(Memory item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return await dbConnection.ExecuteAsync("INSERT INTO dbo.Memories VALUES(@Name,@Description,@Rating,@UploadDate,@Image,@UserId)", item);
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

        public async Task<int> UpdateAsync(Memory item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return await dbConnection.ExecuteAsync("UPDATE dbo.Memories SET name=@Name,description=@Description,rating=@Rating,uploadDate=@UploadDate,image=@Image,userid=@UserId WHERE id = @Id", item);
            }
        }
    }
}
