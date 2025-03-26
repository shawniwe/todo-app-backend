using ToDoApp.Domain.Enums;

namespace ToDoApp.Domain.Entities
{
    // Entity - сущность - таблица в базе данных
    public class Deal
    {
        public int Id { get; set; } // автоматически проставляется в БД
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? Deadline { get; set; } // ? <-- не обязательным (null)
        public DealStatus Status { get; set; }
    }
}
