namespace Ibnt.Server.Application.Dtos.ReactionEntity
{
    public record BibleMessageReactionDto
    {
        public Guid? BibleMessageId { get; init; }
        public string Name { get; init; }
        public Guid MemberId { get; init; }
        public bool Toggled { get; init; }
    }
}
