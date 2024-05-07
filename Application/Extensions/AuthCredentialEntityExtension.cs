using Ibnt.Server.Application.Dtos.AuthCredentialEntity;
using Ibnt.Server.Domain.Entities.Users.Auth;

namespace Ibnt.Server.Application.Extensions
{
    public static class AuthCredentialEntityExtension
    {
        public static AuthResponseDto AsDto(this AuthCredentialEntity auth)
        {
            var authDto = new AuthResponseDto
            {
                Id = auth.MemberId.Value,
                Email = auth.Email,
                Role = auth.Role,
                Token = auth.Token ?? "",
            };
            return authDto;
        }
        public static AuthListDto AsListDto(this AuthCredentialEntity auth)
        {
            var authDto = new AuthListDto
            {
                Id = auth.MemberId,
                Email = auth.Email,
                Role = auth.Role,

            };
            return authDto;
        }
    }

    public static class RecoveryPasswordEntityExtension
    {
        public static RecoveryPasswordDto AsDto(this RecoveryPasswordEntity recoveryPassword)
        {
            return new RecoveryPasswordDto
            {
             FullName = recoveryPassword.FullName,
             VerificationEmail = recoveryPassword.VerificationEmail,
             VerificationCode = recoveryPassword.VerificationCode,
             NewPassword = recoveryPassword.NewPassword,
            };
        }
    }
}
