using Ibnt.Server.Application.Dtos.ReactionEntity;
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

        [HttpPost("events")]
        public async Task<IActionResult> EventReaction([FromBody] CreateEventReactionDto dto)
        {

            ReactionEventEntity reaction = new();

            reaction.ChangeName(dto.Name);
            reaction.ChangeMemberId(dto.MemberId);
            reaction.ChangeEventId(dto.EventId);

            await _repository.Create(reaction);

            return Ok();
        }

        [HttpPost("bible-messages")]
        public async Task<IActionResult> BibleMessageReaction([FromBody] CreateBibleMessageReactionDto dto)
        {

            ReactionBibleMessageEntity reaction = new();

            reaction.ChangeName(dto.Name);
            reaction.ChangeMemberId(dto.MemberId);
            reaction.ChangeBibleMessageId(dto.BibleMessageId);

            await _repository.Create(reaction);

            return Ok();
        }

        [HttpPost("posts")]
        public async Task<IActionResult> PostReaction([FromBody] CreatePostReactionDto dto)
        {

            ReactionPostEntity reaction = new();

            reaction.ChangeName(dto.Name);
            reaction.ChangeMemberId(dto.MemberId);
            reaction.ChangePostId(dto.PostId);

            await _repository.Create(reaction);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var databaseReactions = await _repository.GetAllEventsReactions();
                var reactionsList = databaseReactions.Select(r => r.AsDto()).ToList();
                return Ok(reactionsList);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpGet("event/{eventId}")]
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

        [HttpGet("bible-message/{messageId}")]
        public async Task<IActionResult> GetReactionsByBibleMessageId(Guid messageId)
        {
            try
            {
                var databaseReactions = await _repository.GetReactionsByBibleMessageId(messageId);
                var reactionsList = databaseReactions.Select(r => r.AsDto()).ToList();
                return Ok(reactionsList);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpGet("post/{postId}")]
        public async Task<IActionResult> GetReactionsByPostId(Guid postId)
        {
            try
            {
                var databaseReactions = await _repository.GetReactionsByPostId(postId);
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
