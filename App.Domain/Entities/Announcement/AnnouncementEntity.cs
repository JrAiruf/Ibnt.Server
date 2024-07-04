using App.Domain.Entities.Users;
using App.Domain.Exceptions;

namespace App.Domain.Entities.Announcement
{
    public class AnnouncementEntity
    {
        public AnnouncementEntity(Guid memberId, string title, string description, string dateString,bool? fixedWarning)
        {
            Id = Guid.NewGuid();
            MemberId = memberId;
            ChangeTitle(title);
            ChangeDescription(description);
            ChangeDate(dateString);
            ChangeFixedStatus(fixedWarning ?? false);
        }
        public AnnouncementEntity(string title, string description, string dateString,bool fixedWarning)
        {
            ChangeTitle(title);
            ChangeDescription(description);
            ChangeDate(dateString);
            ChangeFixedStatus(fixedWarning);
        }

        public AnnouncementEntity()
        {

        }
        public Guid Id { get; private set; }
        public Guid MemberId { get; set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime Date { get; private set; }
        public bool FixedWarning { get; private set; }
        public MemberEntity Member { get; private set; }
        public void ChangeTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new AnnouncementException("A propriedade Title não pode ser vazia ou nula.");
            }
            Title = title;
        }

        public void ChangeDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new AnnouncementException("A propriedade Description não pode ser vazia ou nula.");
            }
            Description = description;
        }

        public void ChangeDate(string dateString)
        {
            if (string.IsNullOrEmpty(dateString))
            {

                throw new AnnouncementException("A propriedade Date não pode ser vazia ou nula.");
            }
            else
            {
                DateTime announcementDate = DateTime.Parse(dateString);
                Date = announcementDate;
            }
        }

        public void ChangeFixedStatus(bool fixedWarning)
        {
            FixedWarning = fixedWarning;
        }


    }
}
