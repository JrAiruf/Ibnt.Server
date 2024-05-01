namespace Ibnt.Server.Application.Dtos.AuthCredentialEntity
{
    public class CreateAuthDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Role { get; set; }
    }
}
