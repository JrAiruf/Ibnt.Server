using App.Application.Dtos.EventEntity;
using App.Application.Extensions;
using App.Application.Interfaces;
using App.Domain.Entities.TimeLine;
using App.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml;

namespace Ibnt.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventsRepository _repository;
        public EventsController(IEventsRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("images/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> SetImageFile([FromForm] IFormFile imageFile, Guid id)
        {
            try
            {
                EventEntity currentEvent = await _repository.GetById(id);
                if (currentEvent == null)
                {
                    return NotFound();
                }

                else
                {
                    string pathSection = $"{id}" + imageFile.FileName;

                    string imagePath = $"Images/{pathSection}";

                    string newImagePath = Path.Combine(imagePath);

                    using FileStream file = new FileStream(newImagePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);

                    await imageFile.CopyToAsync(file);

                    return StatusCode(StatusCodes.Status200OK, new {Message = $"New Image Added: {newImagePath}."});
                }
            }
            catch (AppException exception)
            {
                return exception is EventException
                    ? BadRequest(exception.Message)
                    : (IActionResult)StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([FromBody] CreateEventDto dto)
        {
            try
            {
                EventEntity newEvent = new(
                dto.Title,
                dto.PostDate,
                dto.Date,
                dto.Description
                );

                EventEntity createdEvent = await _repository.Create(newEvent);
                return StatusCode(StatusCodes.Status201Created, createdEvent.AsDto());
            }
            catch (AppException exception)
            {
                return exception is EventException
                    ? BadRequest(exception.Message)
                    : (IActionResult)StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<EventEntity> databaseEvents = await _repository.GetAll();
                List<EventListDto> eventsList = databaseEvents.Select(dbEvent => dbEvent.AsListDto()).ToList();
                return Ok(eventsList);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                EventEntity currentEvent = await _repository.GetById(id);
                return currentEvent != null ? Ok(currentEvent.AsDto()) : NotFound();
            }
            catch (Exception exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _repository.Delete(id);
                return NoContent();
            }
            catch (Exception exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

    }
}
