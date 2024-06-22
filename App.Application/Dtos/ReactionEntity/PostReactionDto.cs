namespace App.Application.Dtos.ReactionEntity
{
    public record PostReactionDto
    {
        public Guid? PostId { get; init; }
        public string Name { get; init; }
        public Guid MemberId { get; init; }
        public bool Toggled { get; init; }
    }
}
