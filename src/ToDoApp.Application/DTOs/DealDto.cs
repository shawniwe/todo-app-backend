namespace ToDoApp.Application.DTOs
{
    // DTO - data transfer object - нужен для "визуального" отображения
    public class DealDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? Deadline { get; set; }
        public string Status { get; set; }
    }
}
