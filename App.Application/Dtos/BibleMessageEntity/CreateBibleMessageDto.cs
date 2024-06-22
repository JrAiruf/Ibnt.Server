namespace App.Application.Dtos.BibleMessageEntity
{
    public record CreateBibleMessageDto
    {
        public string Title { get; set; }
        public string BaseText { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
        public Guid MemberId { get; set; }
    }
}
