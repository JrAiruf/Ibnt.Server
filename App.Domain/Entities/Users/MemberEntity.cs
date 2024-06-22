using App.Domain.Entities.Reactions;
using App.Domain.Entities.TimeLine;
using App.Domain.Entities.Users.Auth;
using App.Domain.Exceptions;

namespace App.Domain.Entities.Users
{
    public class MemberEntity
    {
        public MemberEntity(string? fullName, string? profileImage, AuthCredentialEntity? credential)
        {
            ChangeFullName(fullName);
            ChangeProfileImage(profileImage);
            SetCredentials(credential);
        }

        public MemberEntity() { }
        public Guid Id { get; set; }
        public string FullName { get; private set; }
        public string? ProfileImage { get; private set; }
        public AuthCredentialEntity? Credential { get; private set; }
        public List<ReactionEventEntity>? Reactions { get; set; }
        public List<EventEntity>? Events { get; set; }
        public List<BibleMessageEntity>? BibleMessages { get; set; }

        public void ChangeFullName(string? fullName)
        {
            if (string.IsNullOrEmpty(fullName))
            {
                throw new MemberEntityException("A propriedade fullName não pode ser vazia ou nula.");
            }
            FullName = fullName;
        }
        public void ChangeProfileImage(string? profileImage)
        {
            if (profileImage != null)
            {
                if (string.IsNullOrEmpty(profileImage))
                {
                    throw new MemberEntityException("Informe um valor válido para profileImage.");
                }
                ProfileImage = profileImage;
            }
        }
        public void SetCredentials(AuthCredentialEntity? credential)
        {
            if (credential == null)
            {
                throw new MemberEntityException("O usuário não pode ser criado sem credenciais.");
            }
            Credential = new AuthCredentialEntity(credential);
        }
    }
}
