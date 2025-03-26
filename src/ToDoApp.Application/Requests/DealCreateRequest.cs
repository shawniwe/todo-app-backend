namespace ToDoApp.Application.Requests
{
    public class DealCreateRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Deadline { get; set; }
    }
}
