namespace Ibnt.Server.Application.Dtos.ReactionEntity
{
    public record BibleMessageReactionDto
    {
        public string Name { get; init; }
        public Guid MemberId { get; init; }
        public bool Toogled { get; init; }
    }
}
