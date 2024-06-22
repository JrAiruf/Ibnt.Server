using Ibnt.Server.Domain.Exceptions;

namespace Ibnt.Server.Domain.Entities.Users.Auth
{
    public class RecoveryPasswordEntity
    {
        public RecoveryPasswordEntity(string? fullName, string? verificationCode, string? verificationEmail, string? newPassword)
        {
            ChangeFullName(fullName);
            ChangeVerificationCode(verificationCode);
            ChangeVerificationEmail(verificationEmail);
            ChangeNewPassword(newPassword);
        }

        public string? FullName { get; private set; }
        public string? VerificationCode { get; private set; }
        public string? VerificationEmail { get; private set; }
        public string? NewPassword { get; private set; }

        public void ChangeFullName(string? fullName)
        {
            if (string.IsNullOrEmpty(fullName))
            {
                throw new AuthCredentialEntityException("A propriedade fullName não pode ser vazia ou nula.");
            }
            FullName = fullName;
        }
        public void ChangeVerificationCode(string? cerificationCode)
        {
            if (string.IsNullOrEmpty(cerificationCode))
            {
                throw new AuthCredentialEntityException("A propriedade cerificationCode não pode ser vazia ou nula.");
            }
            VerificationCode = cerificationCode;
        }
        public void ChangeVerificationEmail(string? cerificationEmail)
        {
            if (string.IsNullOrEmpty(cerificationEmail))
            {
                throw new AuthCredentialEntityException("A propriedade cerificationEmail não pode ser vazia ou nula.");
            }
            VerificationEmail = cerificationEmail;
        }
        public void ChangeNewPassword(string? newPassword)
        {
            if (string.IsNullOrEmpty(newPassword))
            {
                throw new AuthCredentialEntityException("A propriedade newPassword não pode ser vazia ou nula.");
            }
            NewPassword = newPassword;
        }
    }
}
