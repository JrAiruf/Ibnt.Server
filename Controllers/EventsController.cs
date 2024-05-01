using Ibnt.Server.Application.Dtos.EventEntity;
using Ibnt.Server.Application.Extensions;
using Ibnt.Server.Application.Interfaces;
using Ibnt.Server.Domain.Entities.TimeLine;
using Microsoft.AspNetCore.Mvc;

namespace Ibnt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventsRepository _repository;
        public EventsController(IEventsRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEventDto dto)
        {
            EventEntity newEvent = new(
                dto.Title,
                dto.PostDate,
                dto.Date,
                dto.Description,
                dto.ImageUrl);

            var createdEvent = await _repository.Create(newEvent);
            return StatusCode(StatusCodes.Status201Created, createdEvent.AsDto());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var databaseEvents = await _repository.GetAll();
            var eventsList = databaseEvents.Select(dbEvent => dbEvent.AsListDto()).ToList();
            return Ok(eventsList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var currentEvent = await _repository.GetById(id);
            return Ok(currentEvent.AsDto());
        }
    }
}
