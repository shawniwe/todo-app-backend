using Microsoft.AspNetCore.Mvc;
using ToDoApp.Application.Abstract;
using ToDoApp.Application.DTOs;
using ToDoApp.Application.Requests;

namespace ToDoApp.Presentation.Controllers
{
    // migrations - механизм, управляющий "версиями" базы данных

    // каждое изменение структуры БД = миграция
    // миграция имеет номер версии и два скрипта - up и down - "накатить" и "откатить"
    
    [Route("api/[controller]")]
    [ApiController]
    public class DealController : ControllerBase
    {
        private readonly IDealService _dealService;

        public DealController(IDealService dealService) // инъекция зависимости
        {
            _dealService = dealService;
        }

        [HttpPost]
        public async Task<ActionResult<DealDto>> Create([FromBody] DealCreateRequest request)
        {
            DealDto result = await _dealService.Create(request);
            return Created("/", result); // <-- указать корректную ссылку для получения объекта
        }

        [Route("all")]
        [HttpGet]
        public IActionResult GetAll()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult GetById()
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            throw new NotImplementedException();
        }

        [Route("status")]
        [HttpPatch]
        public IActionResult UpdateStatus()
        {
            throw new NotImplementedException();
        }

        [Route("description")]
        [HttpPatch]
        public IActionResult UpdateDescription()
        {
            throw new NotImplementedException();
        }

        [Route("title")]
        [HttpPatch]
        public IActionResult UpdateTitle()
        {
            throw new NotImplementedException();
        }
    }
}
