﻿using Ibnt.Server.Domain.Entities.Users;

namespace Ibnt.Server.Application.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(AuthCredentialEntity auth);
    }
}
