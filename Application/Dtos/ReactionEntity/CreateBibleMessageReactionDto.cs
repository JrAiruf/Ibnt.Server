namespace Ibnt.Server.Application.Dtos.ReactionEntity
{
    public record CreateBibleMessageReactionDto
    {
        public string Name { get; init; }
        public Guid MemberId { get; init; }
        public Guid BibleMessageId { get; init; }
    }
}
