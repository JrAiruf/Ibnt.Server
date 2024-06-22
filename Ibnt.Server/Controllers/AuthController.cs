using App.Application.Dtos.AuthCredentialEntity;
using App.Application.Extensions;
using App.Application.Interfaces;
using App.Domain.Entities.Users.Auth;
using App.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Net;

namespace Ibnt.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repository;
        private readonly IHashService _hashService;
        private readonly ITokenService _tokenService;
        private readonly RestClient _client;
        public AuthController(IAuthRepository repository,
            IHashService hashService,
            ITokenService tokenService,
            RestClient client)
        {
            _repository = repository;
            _hashService = hashService;
            _tokenService = tokenService;
            _client = client;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var databaseCredentials = await _repository.GetAll();
            var credentials = databaseCredentials.Select(c => c.AsListDto());
            return Ok(credentials);
        }

        [HttpPost]
        [AllowAnonymous]
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
                else
                {
                    return Unauthorized();
                }
            }
            catch (AppException exception)
            {
                if (exception is AuthCredentialEntityException)
                {
                    return BadRequest(exception.Message);
                }
                else if (exception is InvalidCredentialException)
                {
                    return Unauthorized(exception.Message);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
                }
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
        
        [HttpPost("verify-token/{token}")]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyToken(string token)
        {
            try
            {
                var validToken = _tokenService.ValidateToken(token);
                if (validToken)
                {
                return Ok();
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (AppException exception)
            {
                return Unauthorized(exception.Message);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpPost("new-member")]
        [AllowAnonymous]
        public async Task<IActionResult> Create(CreateAuthDto dto)
        {
            try
            {
                AuthCredentialEntity newCredential = new();

                newCredential.ChangeEmail(dto.Email);
                newCredential.ChangePassword(_hashService.HashValue(dto.Password ?? ""));

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

        [HttpPost("send-recovery-code")]
        [AllowAnonymous]
        public async Task<IActionResult> SendRecoveryCode([FromBody] RecoveryPasswordEmailDto dto)
        {
            try
            {
                _client.BaseUrl = new Uri("https://sender.up.railway.app");
                var recoveryPasswordEntity = await _repository.GetCredentialByEmail(dto.Email);
                var emailEntity = new EmailEntity(
                    "ibnt.app@gmail.com",
                    recoveryPasswordEntity.VerificationEmail,
                    "IBNT",
                    recoveryPasswordEntity.FullName,
                    "Recuperação de Senha",
                    $"<h1 style='text-align: center; padding-bottom: 1rem;'> Olá, {recoveryPasswordEntity.FullName}!</h1> <br> <h3 style='text-align: center; padding-bottom: 1rem;'>Seu código de recuperação é:</h3> <br> <p style='text-align: center; font-size:2rem;'>{recoveryPasswordEntity.VerificationCode}</p>"
                    );

                RestRequest request = new RestRequest(method: Method.POST);
                request.Resource = "/api/send";

                request.AddHeader("Content-Type", "application/json");

                request.AddJsonBody(emailEntity);

                request.RequestFormat = DataFormat.Json;
                request.Method = Method.POST;

                var response = _client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return Ok(recoveryPasswordEntity.AsDto());
                }
                else
                {
                    return BadRequest("Erro ao enviar código de verificação.");
                }
            }
            catch (AppException exception)
            {
                if (exception is AuthCredentialEntityException)
                {
                    return NotFound(exception.Message);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
                }
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpPut("password-definition/{verificationCode}")]
        [AllowAnonymous]
        public async Task<IActionResult> DefinePassword(string verificationCode, [FromBody] PasswordDefinitionDto dto)
        {
            try
            {
                var currentRecoveryEntity = await _repository.GetRecoveryPasswordEntityByVerificationCode(verificationCode);
                if (currentRecoveryEntity == null)
                {
                    return NotFound();
                }
                else
                {
                    AuthCredentialEntity authCredentialEntity = new AuthCredentialEntity(dto.Email, dto.Password);
                    await _repository.UpdateCredential(authCredentialEntity);
                    return Ok();
                }
            }
            catch (AppException exception)
            {

                return NotFound(exception.Message);

            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
    }
}
