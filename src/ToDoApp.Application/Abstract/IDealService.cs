using ToDoApp.Application.DTOs;
using ToDoApp.Application.Requests;

namespace ToDoApp.Application.Abstract
{
    // service pattern - оперирует DTO
    // repository pattern - использует сущности (entity)
    public interface IDealService // класс, который обеспечивает работу с той или иной бизнес-сущностью
    {
        Task<DealDto> Create(DealCreateRequest request);
    }
}
