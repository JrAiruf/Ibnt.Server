using Ibnt.Server.Domain.Exceptions;
using System.Text.Json.Serialization;

namespace Ibnt.Server.Domain.Entities.Users.Auth
{

    public class EmailEntity
    {
        public EmailEntity(string senderEmailAddress, string receiverEmailAddress, string senderName, string receiverName, string emailSubject, string emailContent)
        {
            ChangeSenderEmailAddress(senderEmailAddress);
            ChangeReceiverEmailAddress(receiverEmailAddress);
            ChangeSenderName(senderName);
            ChangeReceiverName(receiverName);
            ChangeEmailSubject(emailSubject);
            ChangeEmailContent(emailContent);
        }

        public string SenderEmailAddress { get; private set; }
        public string ReceiverEmailAddress { get; private set; }
        public string SenderName { get; private set; }
        public string ReceiverName { get; private set; }
        public string EmailSubject { get; private set; }
        public string EmailContent { get; private set; }

        public void ChangeSenderEmailAddress(string senderEmailAddress)
        {
            if (string.IsNullOrEmpty(senderEmailAddress))
            {
                throw new EmailFormatException("Sender address is empty. Please, set a valid e-mail address.");
            }
            SenderEmailAddress = senderEmailAddress;
        }
        public void ChangeReceiverEmailAddress(string receiverEmailAddress)
        {
            if (string.IsNullOrEmpty(receiverEmailAddress))
            {
                throw new EmailFormatException("Receiver address is empty. Please, set a valid e-mail address.");
            }
            ReceiverEmailAddress = receiverEmailAddress;
        }

        public void ChangeSenderName(string senderName)
        {
            if (string.IsNullOrEmpty(senderName))
            {
                throw new EmailFormatException("Sender name is empty. Please, set a valid name.");
            }
            SenderName = senderName;
        }
        public void ChangeReceiverName(string receiverName)
        {
            if (string.IsNullOrEmpty(receiverName))
            {
                throw new EmailFormatException("Receiver name is empty. Please, set a valid name.");
            }
            ReceiverName = receiverName;
        }
        public void ChangeEmailSubject(string emailSubject)
        {
            if (string.IsNullOrEmpty(emailSubject))
            {
                throw new EmailFormatException("The e-mail subject has no content.");
            }
            EmailSubject = emailSubject;
        }
        public void ChangeEmailContent(string emailContent)
        {
            if (string.IsNullOrEmpty(emailContent))
            {
                throw new EmailFormatException("The current message has no content.");
            }
            EmailContent = emailContent;
        }
    }
}
