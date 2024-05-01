using Ibnt.Server.Application.Dtos.AuthCredentialEntity;
using Ibnt.Server.Domain.Entities.Users;

namespace Ibnt.Server.Application.Extensions
{
    public static class AuthCredentialEntityExtension
    {
        public static AuthResponseDto AsDto(this AuthCredentialEntity auth)
        {
            var authDto = new AuthResponseDto();
            authDto.Email = auth.Email;
            authDto.Role = auth.Role;
            authDto.Token = auth.Token ?? "";
            return authDto;
        }
        public static AuthListDto AsListDto(this AuthCredentialEntity auth)
        {
            var authDto = new AuthListDto();
            authDto.Id = auth.MemberId;
            authDto.Email = auth.Email;
            authDto.Role = auth.Role;
            return authDto;
        }
    }
}
