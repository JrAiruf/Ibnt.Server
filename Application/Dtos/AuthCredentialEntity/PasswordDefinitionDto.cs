namespace Ibnt.Server.Application.Dtos.AuthCredentialEntity
{
    public record PasswordDefinitionDto
    {
        public string Email{ get; init; }
        public string Password{ get; init; }
    }
}
