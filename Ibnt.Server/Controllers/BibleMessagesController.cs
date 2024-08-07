﻿using App.Domain.Entities.TimeLine;
using App.Application.Dtos.BibleMessageEntity;
using App.Application.Extensions;
using App.Application.Interfaces;
using App.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ibnt.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BibleMessagesController : ControllerBase
    {
        public readonly IBibleMessagesRepository _repository;
        public BibleMessagesController(IBibleMessagesRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBibleMessage([FromBody] CreateBibleMessageDto dto)
        {
            try
            {
                var newMessage = new BibleMessageEntity(
                    dto.Title,
                    dto.BaseText,
                    dto.Type,
                    dto.Content,
                    dto.MemberId
                    );

                var createdMessage = await _repository.Create(newMessage);
                return StatusCode(StatusCodes.Status201Created, createdMessage.AsDto());
            }
            catch (AppException exception)
            {
                if (exception is TimeLineContentException || exception is BibleMessageException)
                {
                    return BadRequest(exception.Message);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var databaseBibleMessages = await _repository.GetAllAsync();
            var bibleMessages = databaseBibleMessages.Select(b => b.AsListDto()).ToList();
            return Ok(bibleMessages);
        }

        [HttpGet("member/{memberId}")]
        public async Task<IActionResult> GetAllMemberMessagesAsync(Guid memberId)
        {
            try
            {
                var databaseBibleMessages = await _repository.GetMessagesByMemberIdAsync(memberId);
                var bibleMessages = databaseBibleMessages.Select(b => b.AsDto()).ToList();
                return Ok(bibleMessages);
            }
            catch (AppException exception)
            {
                if (exception is BibleMessageException)
                {
                    return NotFound(exception.Message);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                var currentMessage = await _repository.GetByIdAsync(id);
                return Ok(currentMessage.AsDto());
            }
            catch (AppException exception)
            {
                if (exception is BibleMessageException)
                {
                    return NotFound(exception.Message);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBibleMessageDto dto)
        {
            try
            {
                var message = new BibleMessageEntity(
                    dto.Title,
                    dto.BaseText,
                    dto.Content
                    );
                var updatedMessage = await _repository.Update(id, message);
                return Ok(updatedMessage.AsDto());
            }
            catch (AppException exception)
            {
                if (exception is BibleMessageException)
                {
                    return NotFound(exception.Message);
                }
                if (exception is TimeLineContentException)
                {
                    return BadRequest(exception.Message);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _repository.Delete(id);
                return Ok(new { message = $"Deleted: {id}" });
            }
            catch (AppException exception)
            {
                if (exception is BibleMessageException)
                {
                    return NotFound(exception.Message);
                }
                if (exception is TimeLineContentException)
                {
                    return BadRequest(exception.Message);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
    }
}
