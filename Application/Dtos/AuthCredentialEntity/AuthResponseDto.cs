﻿namespace Ibnt.Server.Application.Dtos.AuthCredentialEntity
{
    public class AuthResponseDto
    {
        public Guid? Id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
