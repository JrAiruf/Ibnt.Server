namespace Ibnt.Server.Application.Dtos.AuthCredentialEntity
{
    public record CreateAuthDto
    {
        public string Email { get; init; }
        public string Password { get; init; }
        public string? Role { get; init; }
    }
}
