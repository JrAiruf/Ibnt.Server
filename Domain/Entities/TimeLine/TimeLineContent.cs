using Ibnt.Server.Domain.Exceptions;

namespace Ibnt.Server.Domain.Entities.TimeLine
{
    public abstract class TimeLineContent
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime? PostDate { get; set; }
        public DateTime? Date { get; set; }
        public string? Content { get; set; }

        public void ChangeTitle(string? title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new MemberEntityException("A propriedade title não pode ser vazia ou nula.");
            }
            Title = title;
        }
        public void ChangePostDate(DateTime? postDate)
        {
            if (string.IsNullOrEmpty(postDate.ToString()))
            {
                throw new MemberEntityException("A propriedade postDate não pode ser vazia ou nula.");
            }
            PostDate = postDate;
        }
        public void ChangeDate(DateTime? date)
        {
            if (string.IsNullOrEmpty(date.ToString()))
            {
                throw new MemberEntityException("A propriedade date não pode ser vazia ou nula.");
            }
            Date = date;
        }
        public void ChangeContent(string? content)
        {
            if (string.IsNullOrEmpty(content))
            {
                throw new MemberEntityException("A propriedade content não pode ser vazia ou nula.");
            }
            Content = content;
        }
    }
}
