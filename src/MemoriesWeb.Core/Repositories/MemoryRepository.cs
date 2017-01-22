using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using MemoriesWeb.Core.Model;
using MemoriesWeb.Core.Repositories;
using Dapper;
using System;

namespace MemoriesWeb.Core.Repositories
{
    public class MemoryRepository : IMemoryRepository
    {
        public async Task AddMemory(Memory memory, string connectionString)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Open();

                string sqlQuery =
                    @"INSERT INTO [dbo].[UserMemories]([Name],[Description],[Rating],[UploadDate],[UserId]) " +
                    "VALUES (@Name,@Description,@Rating,@UploadDate,@UserId)";
                try
                {
                    await db.ExecuteAsync(sqlQuery, memory);
                }
                catch (Exception e)
                {
                    var ex = e;
                }
                
            }
        }

        public async Task UpdateMemory(Memory memory, string connectionString)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Open();

                string sqlQuery =
                    @"UPDATE [dbo].[UserMemories] SET Name = @Name,Description= @Description,Rating=@Rating,UploadDate=@UploadDate,UserId=@UserId";
                await db.ExecuteAsync(sqlQuery, memory);
            }
        }

        public async Task DeleteMemory(int id, string connectionString)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Open();

                string sqlQuery = "DELETE FROM [dbo].[UserMemories] WHERE id=@Id";
                await db.ExecuteAsync(sqlQuery, new {Id = id});
            }
        }

        public async Task<Memory> GetMemory(int id, string connectionString)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Open();

                string sqlQuery = "SELECT * FROM [dbo].[UserMemories] WHERE id=@Id";
                var result = await db.QueryAsync<Memory>(sqlQuery, new {Id = id});
                return null;
            }
        }

        public async Task<IEnumerable<Memory>> GetAllMemorys(string connectionString)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Open();

                string sqlQuery = "SELECT * FROM [dbo].[UserMemories]";
                return await db.QueryAsync<Memory>(sqlQuery);
            }
        }
    }
}

