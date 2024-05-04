using Ibnt.Server.Application.Dtos.GloryReactionEntity;
using Ibnt.Server.Application.Extensions;
using Ibnt.Server.Application.Interfaces;
using Ibnt.Server.Domain.Entities.Reactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Ibnt.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ReactionsController : ControllerBase
    {
        private readonly IReactionsRepository _repository;
        public ReactionsController(IReactionsRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("glory")]
        public async Task<IActionResult> Create([FromBody] CreateReactionDto dto)
        {

            try
            {
                ReactionEntity reaction = new();

                reaction.ChangeName("Glória");
                reaction.ChangeMemberId(dto.MemberId);
                reaction.ChangeEventId(dto.EventId);

                await _repository.Create(reaction);

                return Ok();
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var databaseReactions = await _repository.GetAll();
                var reactionsList = databaseReactions.Select(r => r.AsDto()).ToList();
                return Ok(reactionsList);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
        [HttpGet("{eventId}")]
        public async Task<IActionResult> GetReactionsByEventId(Guid eventId)
        {
            try
            {
                var databaseReactions = await _repository.GetReactionsByEventId(eventId);
                var reactionsList = databaseReactions.Select(r => r.AsDto()).ToList();
                return Ok(reactionsList);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

    }
}
