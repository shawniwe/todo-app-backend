using ToDoApp.Domain.Entities;

namespace ToDoApp.Domain.Abstract
{
    // repository - реализовывает операции по работе с таблицами в БД
    // CRUD - create, read, update, delete

    // на каждую таблицу - свой "репозиторий"

    public interface IDealRepository
    {
        Task<Deal> Create(Deal deal);
        Task<List<Deal>> GetAll();
        Task<Deal?> GetById(long id);
    }
}
