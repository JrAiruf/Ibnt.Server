namespace App.Application.Dtos.ReactionEntity
{
    public record UpdateReactionDto
    {
        public string Name { get; init; }
        public Guid MemberId { get; init; }
        public Guid ItemId { get; init; }
    }
}
