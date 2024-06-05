namespace Ibnt.Server.Application.Dtos.ReactionEntity
{
    public record CreateReactionDto
    {
        public string Name { get; init; }
        public Guid MemberId { get; init; }
        public Guid ItemId { get; init; }
    }
}
