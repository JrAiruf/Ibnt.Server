namespace App.Application.Dtos.AuthCredentialEntity
{
    public record AuthResponseDto
    {
        public Guid? Id { get; init; }
        public string Email { get; init; }
        public string Role { get; init; }
        public string Token { get; init; }
    }
}
