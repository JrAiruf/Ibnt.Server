namespace Ibnt.Server.Application.Dtos.AuthCredentialEntity
{
    public record AuthListDto
    {
        public Guid? Id { get; init; }
        public string Email { get; init; }
        public string Role { get; init; }
    }
}
