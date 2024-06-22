namespace App.Application.Dtos.ReactionEntity
{
    public record UntoggleReactionDto
    {
        public Guid MemberId { get; init; }
        public Guid ItemId { get; init; }
    }
}
