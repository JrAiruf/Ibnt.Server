﻿namespace App.Application.Dtos.AuthCredentialEntity
{
    public record MemberCredentialDto
    {
        public string Email { get; init; }
        public string Role { get; init; }
        public string Token { get; init; }
    }
}
