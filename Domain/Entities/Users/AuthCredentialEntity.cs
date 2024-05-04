using Ibnt.Server.Domain.Exceptions;

namespace Ibnt.Server.Domain.Entities.Users
{
    public class AuthCredentialEntity
    {
        public AuthCredentialEntity(AuthCredentialEntity credential)
        {
            ChangeEmail(credential.Email);
            ChangePassword(credential.Password);
            ChangeRole(credential.Role);
        }
        public AuthCredentialEntity(string? email, string? password, string? role)
        {
            ChangeEmail(email);
            ChangePassword(password);
            ChangeRole(role);
        }
        public AuthCredentialEntity(string? email, string? password)
        {
            ChangeEmail(email);
            ChangePassword(password);
        }
        public AuthCredentialEntity() { }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string? Token { get; private set; }
        public string Role { get; private set; } = "user";
        public MemberEntity? Member { get; private set; }
        public Guid? MemberId { get; private set; }

        public void ChangeEmail(string? email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new AuthCredentialEntityException("A propriedade email não pode ser vazia ou nula.");
            }
            Email = email;
        }

        public void ChangePassword(string? password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new AuthCredentialEntityException("A propriedade password não pode ser vazia ou nula.");
            }
            Password = password;
        }

        public void ChangeToken(string? token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new AuthCredentialEntityException("A propriedade token não pode ser vazia ou nula.");
            }
            Token = token;
        }

        public void ChangeRole(string? role)
        {
            if (string.IsNullOrEmpty(role))
            {
                throw new AuthCredentialEntityException("Informe um valor válido para a propriedade role.");
            }
            Role = role;
        }

        public void CHangeMemberId(Guid? memberId)
        {
            if (!memberId.HasValue)
            {
                throw new AuthCredentialEntityException("A propriedade memberId não pode ser vazia ou nula.");
            }
            MemberId = memberId;
        }

    }
}
