using SimpleMigrations;

namespace ToDoApp.Migrations.Migrations
{
    [Migration(version: 20250326_2036, "Создана таблица Deal для хранения задач")]
    public class _20250326_2036_CreateDealTable : Migration
    {
        protected override void Down()
        {
            Execute("DROP TABLE [deal];");
        }

        protected override void Up()
        {
            Execute(@"CREATE TABLE [deal]
                    (
	                    Id INT NOT NULL IDENTITY (1, 1) PRIMARY KEY,
	                    Title NVARCHAR(64) NOT NULL,
	                    [Description] TEXT NULL,
	                    Deadline DATETIME NULL,
	                    [Status] TINYINT NOT NULL DEFAULT(0)
                    )");
        }
    }
}
