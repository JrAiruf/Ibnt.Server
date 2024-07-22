using App.Application.Dtos.EventEntity;
using App.Application.Extensions;
using App.Application.Interfaces;
using App.Domain.Entities.TimeLine;
using App.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestSharp.Extensions;

namespace Ibnt.API.Controllers
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

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([FromBody] CreateEventDto dto)
        {
            try
            {
                var imageFile = Request.Form.Files.First();
                string fileName = "";
                FileStream file = new FileStream(imageFile.FileName, FileMode.Create);
                await imageFile.CopyToAsync(file);

                List<string> transformedBytes = file.ReadAsBytes().Select(b => b.ToString()).ToList();
                transformedBytes.ForEach((caracter) =>
                {
                    fileName = $"{caracter},";
                    Console.WriteLine(fileName);
                });

                EventEntity newEvent = new(
                dto.Title,
                dto.PostDate,
                dto.Date,
                dto.Description,
                fileName);

                var createdEvent = await _repository.Create(newEvent);
                return StatusCode(StatusCodes.Status201Created, createdEvent.AsDto());
            }
            catch (AppException exception)
            {
                if (exception is EventException)
                {
                    return BadRequest(exception.Message);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
                }
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
                var databaseEvents = await _repository.GetAll();
                var eventsList = databaseEvents.Select(dbEvent => dbEvent.AsListDto()).ToList();
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
                var currentEvent = await _repository.GetById(id);
                if (currentEvent != null)
                {
                    return Ok(currentEvent.AsDto());
                }
                else
                {
                    return NotFound();
                }
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
