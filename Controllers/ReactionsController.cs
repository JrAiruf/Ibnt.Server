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
        public async Task<IActionResult> EventReaction([FromBody] CreateReactionDto dto)
        {

            ReactionEventEntity reaction = new();

            reaction.ChangeName(dto.Name);
            reaction.ChangeMemberId(dto.MemberId);
            reaction.ChangeEventId(dto.ItemId);

            var newReation = await _repository.Create(reaction);

            return Ok(newReation.AsDto());
        }

        [HttpPost("bible-messages")]
        public async Task<IActionResult> BibleMessageReaction([FromBody] CreateReactionDto dto)
        {

            ReactionBibleMessageEntity reaction = new();

            reaction.ChangeName(dto.Name);
            reaction.ChangeMemberId(dto.MemberId);
            reaction.ChangeBibleMessageId(dto.ItemId);

            var newReation = await _repository.Create(reaction);

            return Ok(newReation.AsDto());
        }

        [HttpPost("posts")]
        public async Task<IActionResult> PostReaction([FromBody] CreateReactionDto dto)
        {

            ReactionPostEntity reaction = new();

            reaction.ChangeName(dto.Name);
            reaction.ChangeMemberId(dto.MemberId);
            reaction.ChangePostId(dto.ItemId);

            var newReation = await _repository.Create(reaction);

            return Ok(newReation.AsDto());
        }
        
        [HttpPut("events")]
        public async Task<IActionResult> UpdateEventReaction([FromBody] CreateReactionDto dto)
        {

            ReactionEventEntity reaction = new();

            reaction.ChangeName(dto.Name);
            reaction.ChangeMemberId(dto.MemberId);
            reaction.ChangeEventId(dto.ItemId);

            var newReation = await _repository.Update(reaction);

            return Ok(newReation.AsDto());
        }

        [HttpPut("bible-messages")]
        public async Task<IActionResult> UPdateBibleMessageReaction([FromBody] CreateReactionDto dto)
        {

            ReactionBibleMessageEntity reaction = new();

            reaction.ChangeName(dto.Name);
            reaction.ChangeMemberId(dto.MemberId);
            reaction.ChangeBibleMessageId(dto.ItemId);

            var newReation = await _repository.Update(reaction);

            return Ok(newReation.AsDto());
        }

        [HttpPut("posts")]
        public async Task<IActionResult> UpdatePostReaction([FromBody] CreateReactionDto dto)
        {

            ReactionPostEntity reaction = new();

            reaction.ChangeName(dto.Name);
            reaction.ChangeMemberId(dto.MemberId);
            reaction.ChangePostId(dto.ItemId);

            var newReation = await _repository.Update(reaction);

            return Ok(newReation.AsDto());
        }

        [HttpGet("events")]
        public async Task<IActionResult> GetAllEventsReactions()
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
        
        [HttpGet("bible-messages")]
        public async Task<IActionResult> GetAllBibleMessagesReactions()
        {
            try
            {
                var databaseReactions = await _repository.GetAllBibleMessagesReactions();
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
       
        [HttpDelete("remove-reaction")]
        public async Task<IActionResult> RemoveReaction(UntoggleReactionDto dto)
        {
            try
            {
                await _repository.UntoggleReaction(dto.MemberId,dto.ItemId);
                return NoContent();
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

    }
}
