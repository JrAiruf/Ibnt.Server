using Ibnt.Server.Application.Dtos.GloryReactionEntity;
using Ibnt.Server.Application.Extensions;
using Ibnt.Server.Application.Interfaces;
using Ibnt.Server.Domain.Entities.Reactions;
using Microsoft.AspNetCore.Mvc;
namespace Ibnt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

            ReactionEntity reaction = new();

            reaction.ChangeName("Glória");
            reaction.ChangeMemberId(dto.MemberId);
            reaction.ChangeEventId(dto.EventId);

            await _repository.Create(reaction);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var databaseReactions = await _repository.GetAll();
            var reactionsList = databaseReactions.Select(r => r.AsDto()).ToList();
            return Ok(reactionsList);
        }
        [HttpGet("{eventId}")]
        public async Task<IActionResult> GetReactionsByEventId(Guid eventId)
        {
            var databaseReactions = await _repository.GetReactionsByEventId(eventId);
            var reactionsList = databaseReactions.Select(r => r.AsDto()).ToList();
            return Ok(reactionsList);
        }

    }
}
