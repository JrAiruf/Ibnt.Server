using Ibnt.Server.Application.Dtos.MemberEntity;
using Ibnt.Server.Application.Extensions;
using Ibnt.Server.Application.Interfaces;
using Ibnt.Server.Domain.Entities.Users;
using Ibnt.Server.Domain.Entities.Users.Auth;
using Ibnt.Server.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ibnt.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly IMembersRepository _repository;
        private readonly IHashService _hashService;
        private readonly ITokenService _tokenService;
        public MembersController(IMembersRepository repository, IHashService hashService, ITokenService tokenService)
        {
            _repository = repository;
            _hashService = hashService;
            _tokenService = tokenService;

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMemberDto dto)
        {
            try
            {
                AuthCredentialEntity credential = new(
                    dto.Credential.Email,
                    _hashService.HashValue(dto.Credential.Password)
                    );

                if (dto.Credential.Role != null)
                {
                    credential.ChangeRole(dto.Credential.Role);
                }

                var newMember = new MemberEntity(
                    dto.FullName,
                    dto.ProfileImage,
                    credential
                    );

                var createdMember = await _repository.Create(newMember);

                var token = _tokenService.GenerateToken(createdMember.Credential);
                createdMember.Credential.ChangeToken(token);

                return StatusCode(StatusCodes.Status201Created, createdMember.AsDto());
            }
            catch (AppException exception)
            {
                if (exception is MemberEntityException || exception is ExistingUserException)
                {
                    return BadRequest(exception.Message);
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

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var databaseMembers = await _repository.GetAll();
                var members = databaseMembers.Select(m => m.AsDtoList()).ToList();
                return Ok(members);
            }
            catch (AppException exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var member = await _repository.GetById(id);
                if (member == null)
                {
                    return NotFound(new { sendedId = id });
                }
                return Ok(member.AsDto());
            }
            catch (AppException exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
