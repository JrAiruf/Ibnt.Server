﻿using App.Application.Dtos.AnnouncementEntity;
using App.Application.Extensions;
using App.Application.Interfaces;
using App.Domain.Entities.Announcement;
using App.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ibnt.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AnnouncementsController : ControllerBase
    {
        private readonly IAnnouncementsRepository _repository;
        public AnnouncementsController(IAnnouncementsRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<Results<BadRequest<string>, Created<AnnouncementDto>>> Create([FromBody] CreateAnnouncementDto dto)
        {
            (AppException? exception, AnnouncementEntity? announcement) = await _repository.Create(dto);

            if (exception != null)
            {
                return TypedResults.BadRequest(exception.Message);
            }
            else
            {
                return TypedResults.Created("/api/controller", announcement!.AsDto());
            }
        }

        [HttpPost("list")]
        public async Task<Results<BadRequest<string>, Created<List<AnnouncementDto>>>> CreateManyAsync([FromBody] List<CreateAnnouncementDto> dtosList)
        {
            (AppException? exception, List<AnnouncementEntity>? announcements) = await _repository.CreateManyAsync(dtosList);

            if (exception != null)
            {
                return TypedResults.BadRequest(exception.Message);
            }
            else
            {
                var updatedList = announcements?.Select(a => a.AsDto()).ToList();
                return TypedResults.Created("/api/controller", updatedList);
            }
        }

        [HttpGet]
        public async Task<Results<BadRequest<string>, Ok<List<AnnouncementDto>>>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            var announcements = list.Select(a => a.AsDto()).ToList();
            return TypedResults.Ok(announcements);
        }

        [HttpGet("{id}")]
        public async Task<Results<NotFound<string>, Ok<AnnouncementDto>>> GetByIdAsync(Guid id)
        {
            (AppException? exception, AnnouncementEntity? announcement) = await _repository.GetByIdAsync(id);

            if (exception != null)
            {
                return TypedResults.NotFound(exception.Message);
            }
            else
            {
                return TypedResults.Ok(announcement!.AsDto());
            }
        }

        [HttpPut("{id}")]
        public async Task<Results<BadRequest<string>, Ok<AnnouncementDto>>> UpdateAsync(Guid id, [FromBody] UpdateAnnouncementDto dto)
        {
            (AppException? exception, AnnouncementEntity? announcement) = await _repository.UpdateAsync(id, dto);

            if (exception != null)
            {
                return TypedResults.BadRequest(exception.Message);
            }
            else
            {
                return TypedResults.Ok(announcement!.AsDto());
            }
        }

        [HttpDelete("{id}")]
        public async Task<Results<NotFound<string>, Ok<Guid>>> DeleteAsync(Guid id)
        {
            (AppException? exception, Guid? announcementId) = await _repository.DeleteAsync(id);

            if (exception != null)
            {
                return TypedResults.NotFound(exception.Message);
            }
            else
            {
                return TypedResults.Ok(announcementId!.Value);
            }
        }
    }
}