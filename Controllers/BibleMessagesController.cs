using Ibnt.Domain.Entities.TimeLine;
using Ibnt.Server.Application.Dtos.BibleMessageEntity;
using Ibnt.Server.Application.Extensions;
using Ibnt.Server.Application.Interfaces;
using Ibnt.Server.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ibnt.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BibleMessagesController : ControllerBase
    {
        public readonly IBibleMessagesRepository _repository;
        public BibleMessagesController(IBibleMessagesRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBibleMessage([FromBody] CreateBibleMessageDto dto)
        {
            try
            {
                var newMessage = new BibleMessageEntity(
                    dto.Title,
                    dto.BaseText,
                    dto.Content,
                    dto.MemberId
                    );
                var createdMessage = await _repository.Ceate(newMessage);
                return StatusCode(StatusCodes.Status201Created, createdMessage.AsDto());
            }
            catch (AppException exception)
            {
                if (exception is TimeLineContentException || exception is MemberEntityException)
                {
                    return BadRequest(exception.Message);
                }
                throw;
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var databaseBibleMessages = await _repository.GetAllAsync();
            var bibleMessages = databaseBibleMessages.Select(b => b.AsListDto()).ToList();
            return Ok(bibleMessages);
        }
    }
}
