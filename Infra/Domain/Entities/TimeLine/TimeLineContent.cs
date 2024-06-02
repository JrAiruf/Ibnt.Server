using Ibnt.Server.Domain.Exceptions;

namespace Ibnt.Server.Domain.Entities.TimeLine
{
    public abstract class TimeLineContent
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime? PostDate { get; set; } = DateTime.Now;
        public DateTime? CreationDate { get; set; } = DateTime.Now;
        public DateTime? Date { get; set; } = DateTime.Now;
        public string? Content { get; set; }
        public string? EntityType { get; private set; }
        public void ChangeTitle(string? title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new TimeLineContentException("A propriedade title não pode ser vazia ou nula.");
            }
            Title = title;
        }
        public void ChangePostDate(DateTime? postDate)
        {
            if (string.IsNullOrEmpty(postDate.ToString()))
            {
                throw new TimeLineContentException("A propriedade postDate não pode ser vazia ou nula.");
            }
            PostDate = postDate;
        }
        public void ChangeCreationDate(DateTime? creationDate)
        {
            if (string.IsNullOrEmpty(creationDate.ToString()))
            {
                throw new TimeLineContentException("A propriedade creationDate não pode ser vazia ou nula.");
            }
            CreationDate = creationDate;
        }
        public void ChangeDate(DateTime? date)
        {
            if (string.IsNullOrEmpty(date.ToString()))
            {
                throw new TimeLineContentException("A propriedade date não pode ser vazia ou nula.");
            }
            Date = date;
        }
        public void ChangeContent(string? content)
        {
            if (string.IsNullOrEmpty(content))
            {
                throw new TimeLineContentException("A propriedade content não pode ser vazia ou nula.");
            }
            Content = content;
        }
        public void ChangeEntityType(string? entityType)
        {
            if (string.IsNullOrEmpty(entityType))
            {
                throw new TimeLineContentException("A propriedade entityType não pode ser vazia ou nula.");
            }
            EntityType = entityType;
        }
    }
}
