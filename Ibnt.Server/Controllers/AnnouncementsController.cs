using App.Application.Dtos.AnnouncementEntity;
using App.Application.Extensions;
using App.Application.Interfaces;
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
            var (exception, announcement) = await _repository.Create(dto);
            if (exception != null)
            {
                return TypedResults.BadRequest(exception.Message);
            }
            else
            {
                return TypedResults.Created("/api/controller", announcement!.AsDto());
            }
        }
    }
}