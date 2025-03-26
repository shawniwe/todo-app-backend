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
                Deal? entity = await connection.QueryFirstOrDefaultAsync<Deal>(sql, deal);
                if (entity == null)
                    throw new InvalidOperationException("Не удалось вставить сущность в базу данных");

                return entity;
            }
        }
    }
}
