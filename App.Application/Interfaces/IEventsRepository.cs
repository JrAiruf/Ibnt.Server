﻿using App.Domain.Entities.TimeLine;

namespace App.Application.Interfaces
{
    public interface IEventsRepository
    {
        public Task<EventEntity> Create(EventEntity newEvent);
        public Task<IEnumerable<EventEntity>> GetAll();
        public Task<EventEntity> GetById(Guid id);
        public Task<EventEntity> Update(Guid id, EventEntity eventToUpdate);
        public Task Delete(Guid id);
    }
}
