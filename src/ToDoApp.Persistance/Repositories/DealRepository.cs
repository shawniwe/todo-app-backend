using Dapper;
using Microsoft.Data.SqlClient;
using ToDoApp.Domain.Abstract;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Persistance.Repositories
{
    public class DealRepository : IDealRepository
    {
        private readonly ConnectionString _connectionString;

        public DealRepository(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Deal> Create(Deal deal)
        {
            string sql = @"INSERT INTO [deal] (title, description, deadline, status)
                           OUTPUT inserted.Id, inserted.Title, inserted.Description, inserted.Deadline, inserted.Status
                           VALUES (@Title, @Description, @Deadline, @Status)";

            using (var connection = new SqlConnection(_connectionString.Value))
            {
                Deal entity = await connection.QueryFirstAsync<Deal>(sql, deal);
                
                return entity;
            }
        }

        public async Task<List<Deal>> GetAll()
        {
            string sql = @"SELECT [id], [title], [description], [deadline], [status] FROM [deal]";

            using (var connection = new SqlConnection(_connectionString.Value))
            {
                IEnumerable<Deal> entities = await connection.QueryAsync<Deal>(sql);

                return entities.ToList();
            }
        }

        public async Task<Deal?> GetById(long id)
        {
            string sql = @"SELECT [id], [title], [description], [deadline], [status] FROM [deal] WHERE id = @id";

            using (var connection = new SqlConnection(_connectionString.Value))
            {
                Deal? entity = await connection.QueryFirstOrDefaultAsync<Deal>(sql, new { id });
                return entity;
            }
        }
    }
}

// Kerstel server -> 500 (Internal Server Error)
//