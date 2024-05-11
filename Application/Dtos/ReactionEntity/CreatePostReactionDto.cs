namespace Ibnt.Server.Application.Dtos.ReactionEntity
{
    public record CreatePostReactionDto
    {
        public string Name { get; init; }
        public Guid MemberId { get; init; }
        public Guid PostId { get; init; }
    }
}
