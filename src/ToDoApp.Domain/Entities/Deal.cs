using ToDoApp.Domain.Enums;

namespace ToDoApp.Domain.Entities
{
    public class Deal
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public DealStatus Status { get; set; }
    }
}
