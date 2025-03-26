
using Microsoft.Data.SqlClient;
using SimpleMigrations;
using SimpleMigrations.Console;
using SimpleMigrations.DatabaseProvider;
using ToDoApp.Application.Abstract;
using ToDoApp.Application.Services;
using ToDoApp.Domain.Abstract;
using ToDoApp.Migrations.Migrations;
using ToDoApp.Persistance;
using ToDoApp.Persistance.Repositories;

namespace ToDoApp.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IDealRepository, DealRepository>();
            builder.Services.AddScoped<IDealService, DealService>();

            ConnectionString connectionString = new ConnectionString();
            connectionString.Value = "Server=(localdb)\\mssqllocaldb;Database=todoapp_db;Trusted_Connection=True;"; // плохая практика, т.к. это чувствительные данные, нужно хранить в .env

            builder.Services.AddSingleton(connectionString);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            // 1. подключиться к бд
            // 2. применить не примененные миграции

            var migrationsAssembly = typeof(_20250326_2036_CreateDealTable).Assembly;
            using (var connection = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=todoapp_db;Trusted_Connection=True;")) // mssqlconnection
            {
                var databaseProvider = new MssqlDatabaseProvider(connection);
                var migrator = new SimpleMigrator(migrationsAssembly, databaseProvider);

                migrator.Load();
                migrator.MigrateToLatest();
            }

            app.Run(); // infinite cycle
        }
    }
}

// ORM - Object Relational Mapping -> значения базы данных хранятся в объектах (классах)

// Entity Framework (ORM) - самый главный недостаток - СКОРОСТЬ, невозможность использовать short object'ы (или это сделано криво)

// Dapper (micro ORM) - маппинг данных из БД на объекты классов
// чистый SQL