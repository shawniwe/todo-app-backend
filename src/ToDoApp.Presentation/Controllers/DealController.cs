using Microsoft.AspNetCore.Mvc;
using ToDoApp.Application.Abstract;
using ToDoApp.Application.DTOs;
using ToDoApp.Application.Requests;

namespace ToDoApp.Presentation.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class DealController : ControllerBase
    {
        private readonly IDealService _dealService;

        public DealController(IDealService dealService)
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
        public async Task<ActionResult<List<DealDto>>> GetAll()
        {
            List<DealDto> deals = await _dealService.GetDeals();

            if (!deals.Any())
                return NoContent();

            return Ok(deals);
        }

        [HttpGet]
        public async Task<ActionResult<DealDto>> GetById(long id)
        {
            DealDto? deal = await _dealService.GetDeal(id);

            if (deal == null)
                return NoContent();

            return Ok(deal);
        }

        // TODO: доделать end-point'ы + КАРТИНКИ!
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
