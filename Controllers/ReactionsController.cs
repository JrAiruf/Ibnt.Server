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

            await _repository.Create(reaction);

            var databaseEventsReactions = await _repository.GetAllEventsReactions();
            var eventsReactions = databaseEventsReactions.Select(e => e.AsDto()).ToList();
            return Ok(eventsReactions);
        }

        [HttpPost("bible-messages")]
        public async Task<IActionResult> BibleMessageReaction([FromBody] CreateReactionDto dto)
        {

            ReactionBibleMessageEntity reaction = new();

            reaction.ChangeName(dto.Name);
            reaction.ChangeMemberId(dto.MemberId);
            reaction.ChangeBibleMessageId(dto.ItemId);

            await _repository.Create(reaction);

            var databaseBibleMessagesReactions = await _repository.GetAllBibleMessagesReactions();
            var bibleMessagesReactions = databaseBibleMessagesReactions.Select(b => b.AsDto()).ToList();
            return Ok(bibleMessagesReactions);
        }

        [HttpPost("posts")]
        public async Task<IActionResult> PostReaction([FromBody] CreateReactionDto dto)
        {

            ReactionPostEntity reaction = new();

            reaction.ChangeName(dto.Name);
            reaction.ChangeMemberId(dto.MemberId);
            reaction.ChangePostId(dto.ItemId);

            await _repository.Create(reaction);

            var databasePostsReactions = await _repository.GetAllPostsReactions();
            var bibleMessagesReactions = databasePostsReactions.Select(b => b.AsDto()).ToList();
            return Ok(bibleMessagesReactions);
        }
        
        [HttpPut("events")]
        public async Task<IActionResult> UpdateEventReaction([FromBody] UpdateReactionDto dto)
        {

            ReactionEventEntity reaction = new();

            reaction.ChangeName(dto.Name);
            reaction.ChangeMemberId(dto.MemberId);
            reaction.ChangeEventId(dto.ItemId);

            await _repository.Update(reaction);

            var databaseEventsReactions = await _repository.GetAllEventsReactions();
            var eventsReactions = databaseEventsReactions.Select(e => e.AsDto()).ToList();
            return Ok(eventsReactions);
        }

        [HttpPut("bible-messages")]
        public async Task<IActionResult> UpdateBibleMessageReaction([FromBody] UpdateReactionDto dto)
        {

            ReactionBibleMessageEntity reaction = new();

            reaction.ChangeName(dto.Name);
            reaction.ChangeMemberId(dto.MemberId);
            reaction.ChangeBibleMessageId(dto.ItemId);

            await _repository.Update(reaction);

            var databaseBibleMessagesReactions = await _repository.GetAllBibleMessagesReactions();
            var bibleMessagesReactions = databaseBibleMessagesReactions.Select(b => b.AsDto()).ToList();
            return Ok(bibleMessagesReactions);
        }

        [HttpPut("posts")]
        public async Task<IActionResult> UpdatePostReaction([FromBody] UpdateReactionDto dto)
        {

            ReactionPostEntity reaction = new();

            reaction.ChangeName(dto.Name);
            reaction.ChangeMemberId(dto.MemberId);
            reaction.ChangePostId(dto.ItemId);

            await _repository.Update(reaction);

            var databasePostsReactions = await _repository.GetAllPostsReactions();
            var bibleMessagesReactions = databasePostsReactions.Select(b => b.AsDto()).ToList();
            return Ok(bibleMessagesReactions);
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
