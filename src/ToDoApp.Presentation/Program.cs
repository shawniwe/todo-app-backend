using Microsoft.Data.SqlClient;
using SimpleMigrations;
using SimpleMigrations.DatabaseProvider;
using ToDoApp.Application.Abstract;
using ToDoApp.Application.Services;
using ToDoApp.Domain.Abstract;
using ToDoApp.Migrations.Migrations;
using ToDoApp.Persistance;
using ToDoApp.Persistance.Repositories;

namespace ToDoApp.Presentation
{
    /* 
     * Чувствительные данные - это ЛЮБАЯ информация, которая является секретом (пароли, строка подключения к БД,
     * адреса внутренних API и т. д).
     * 
     * Способы хранения чувств. данных:
     * 1. env
     * 2. secret storage
     * 
     * env - environment - "окружение". Некое "хранилище" значений внутри операционной системы
     * 
     * Формат env:
     * НАЗВАНИЕ_ПЕРЕМЕННОЙ="алдвпоалолполав"
     * 
     * Извлечение env:
     * Environment.GetEnvironmentVariable("НАЗВАНИЕ ПЕРЕМЕННОЙ");
     * 
     * Docker (Kuber) ->
     * ENV файл: .env
     * При запуске контейнера файл передается внутрь и механизмы docker (и kuber) устанавливают переменные из файла
     * в качестве переменных ОС
     * 
     * .env файл НЕ пушится в репозиторий!!!
     * 
     * TFS Azure (CI/CD) -> автоматически заполняет .env переменные из указанных на сервере
     */

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
            connectionString.Value = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? throw new ArgumentException("Строка подключения не представлена в .env файле");

            builder.Services.AddSingleton(connectionString);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            var migrationsAssembly = typeof(_20250326_2036_CreateDealTable).Assembly;
            using (var connection = new SqlConnection(connectionString.Value))
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
