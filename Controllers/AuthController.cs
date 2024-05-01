using Ibnt.Server.Application.Dtos.AuthCredentialEntity;
using Ibnt.Server.Application.Extensions;
using Ibnt.Server.Application.Interfaces;
using Ibnt.Server.Domain.Entities.Users;
using Ibnt.Server.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Ibnt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repository;
        private readonly IHashService _hashService;
        private readonly ITokenService _tokenService;
        public AuthController(IAuthRepository repository, IHashService hashService, ITokenService tokenService)
        {
            _repository = repository;
            _hashService = hashService;
            _tokenService = tokenService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var databaseCredentials = await _repository.GetAll();
            var credentials = databaseCredentials.Select(c => c.AsListDto());
            return Ok(credentials);
        }
        [HttpPost]
        public async Task<IActionResult> Authenticate(AuthDto dto)
        {
            try
            {
                var authResult = await _repository.GetCredential(dto.Email, dto.Password);
                if (authResult != null)
                {
                    string token = _tokenService.GenerateToken(authResult);
                    authResult.ChangeToken(token);
                    return Ok(authResult.AsDto());
                }
                return Unauthorized();
            }
            catch (AppException exception)
            {
                if (exception is AuthCredentialEntityException)
                {
                    return BadRequest(exception.Message);
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpPost("new-member")]
        public async Task<IActionResult> Create(CreateAuthDto dto)
        {
            try
            {
                AuthCredentialEntity newCredential = new();
                if (dto.Role != null)
                {
                    newCredential.ChangeRole(dto.Role);
                }
                newCredential.ChangeEmail(dto.Email);
                newCredential.ChangePassword(_hashService.HashValue(dto.Password));

                var authResult = await _repository.Create(newCredential);
                string token = _tokenService.GenerateToken(authResult);
                authResult.ChangeToken(token);

                return Ok(authResult.AsDto());
            }
            catch (AppException exception)
            {
                if (exception is AuthCredentialEntityException)
                {
                    return BadRequest(exception.Message);
                }
                else if (exception is ExistingUserException)
                {
                    return BadRequest(exception.Message);

                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
    }
}
