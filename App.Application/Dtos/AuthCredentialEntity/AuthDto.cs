namespace App.Application.Dtos.AuthCredentialEntity
{
    public record AuthDto
    {
        public string Email { get; init; }
        public string Password { get; init; }
    }
}
