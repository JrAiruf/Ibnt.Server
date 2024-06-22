namespace App.Application.Dtos.AuthCredentialEntity
{
    public record RecoveryPasswordDto
    {
        public string? FullName { get; init; }
        public string? VerificationCode { get; init; }
        public string? VerificationEmail { get; init; }
        public string? NewPassword { get; init; }
    }
}
