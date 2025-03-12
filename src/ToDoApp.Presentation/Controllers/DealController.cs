using Microsoft.AspNetCore.Mvc;

namespace ToDoApp.Presentation.Controllers
{
    // TODO: вынести АРГУМЕНТЫ end-point'ов в ОТДЕЛЬНЫЕ КЛАССЫ

    [Route("api/[controller]")] // <-- общепринятый паттерн начинать доступ
                                // к API со /api/
    [ApiController]
    public class DealController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create()
        {
            throw new NotImplementedException();
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

        // TODO: изменить route в случае возникновения конфликтов
        [HttpDelete]
        public IActionResult Delete()
        {
            throw new NotImplementedException();
        }

        [HttpPatch]
        public IActionResult UpdateStatus()
        {
            throw new NotImplementedException();
        }

        [HttpPatch]
        public IActionResult UpdateDescription()
        {
            throw new NotImplementedException();
        }

        [HttpPatch]
        public IActionResult UpdateTitle()
        {
            throw new NotImplementedException();
        }
    }
}
