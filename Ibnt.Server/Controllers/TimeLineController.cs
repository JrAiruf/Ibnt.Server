using App.Application.Extensions;
using App.Application.Interfaces;
using App.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ibnt.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeLineController : ControllerBase
    {
        private readonly ITimeLineRepository _repository;
        public TimeLineController(ITimeLineRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> StartTimeLine()
        {
            var timeline = await _repository.StartTimeLine();
            return Ok(timeline);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetTimeLineAsync()
        {
            var timeline = await _repository.GetTimeLineAsync();
            return Ok(timeline.AsDto());
        }

        [HttpPost("event/{eventId}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> PostEventAsync(Guid eventId)
        {
            try
            {
                await _repository.PostEvent(eventId);
                return Ok("New Event Posted.");
            }
            catch (AppException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost("event/{eventId}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> RemoveEventAsync(Guid eventId)
        {
            try
            {
                await _repository.RemoveEvent(eventId);
                return Ok("Event Removed.");
            }
            catch (AppException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost("message/{messageId}")]
        [Authorize]
        public async Task<IActionResult> PostBibleMessageAsync(Guid messageId)
        {
            try
            {
                await _repository.PostBibleMessage(messageId);
                return Ok("New Bible Message Posted.");
            }
            catch (AppException exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
