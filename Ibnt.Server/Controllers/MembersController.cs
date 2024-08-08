using App.Application.Dtos.MemberEntity;
using App.Application.Extensions;
using App.Application.Interfaces;
using App.Domain.Entities.TimeLine;
using App.Domain.Entities.Users;
using App.Domain.Entities.Users.Auth;
using App.Domain.Exceptions;
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

        [HttpPost("images/{id}")]
        public async Task<IActionResult> SetImageFile([FromForm] IFormFile imageFile, Guid id)
        {
            try
            {
                MemberEntity currentMember = await _repository.GetById(id);
                if (currentMember == null)
                {
                    return NotFound();
                }

                else
                {
                    string pathSection = $"{id}" + imageFile.FileName;

                    string imagePath = $"Images/Users/{pathSection}";

                    string newImagePath = Path.Combine(imagePath);

                    using FileStream file = new(newImagePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);

                    await imageFile.CopyToAsync(file);

                    currentMember.ChangeProfileImage(newImagePath);

                    _ = await _repository.UpdateAsync(id, currentMember);

                    return StatusCode(StatusCodes.Status200OK, currentMember.AsDtoList());
                }
            }
            catch (AppException exception)
            {
                return exception is EventException
                    ? BadRequest(exception.Message)
                    : (IActionResult)StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

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
