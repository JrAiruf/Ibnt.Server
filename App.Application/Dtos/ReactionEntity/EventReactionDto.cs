namespace App.Application.Dtos.ReactionEntity
{
    public record EventReactionDto
    {
        public Guid ? EventId { get; set; }
        public string Name { get; init; }
        public Guid MemberId { get; init; }
        public bool Toggled { get; init; }
    }
}
