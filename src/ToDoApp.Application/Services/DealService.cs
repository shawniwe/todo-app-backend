using ToDoApp.Application.Abstract;
using ToDoApp.Application.DTOs;
using ToDoApp.Application.Requests;
using ToDoApp.Domain.Abstract;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Enums;

namespace ToDoApp.Application.Services
{
    public class DealService : IDealService
    {
        private readonly IDealRepository _dealRepository;

        public DealService(IDealRepository dealRepository)
        {
            _dealRepository = dealRepository;
        }

        public async Task<DealDto> Create(DealCreateRequest request)
        {
            Deal entity = new Deal();

            if (string.IsNullOrWhiteSpace(request.Title))
                entity.Title = "Без названия";
            else
                entity.Title = request.Title;

            entity.Deadline = request.Deadline;
            entity.Description = request.Description;
            entity.Status = DealStatus.Created;

            entity = await _dealRepository.Create(entity);

            DealDto model = new DealDto();

            model.Id = entity.Id;
            model.Title = entity.Title;
            model.Deadline = entity.Deadline;
            model.Description = entity.Description;
            model.Status = GetStringStatus(entity.Status);

            return model;
        }

        public string GetStringStatus(DealStatus status)
        {
            switch (status)
            {
                case DealStatus.Created:
                    return "Создана";
                case DealStatus.InProgress:
                    return "В процессе";
                case DealStatus.Done:
                    return "Выполнена";
                default:
                    throw new NotImplementedException("Неизвестный статус задачи");
            }
        }
    }
}
