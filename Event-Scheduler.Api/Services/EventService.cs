using Event_Scheduler.Api.Dto;
using Event_Scheduler.Api.Extensions;
using Event_Scheduler.Api.Models;
using Event_Scheduler.Api.Repository;

namespace Event_Scheduler.Api.Services
{
    public interface IEventService
    {
        Task<Event> AddAsync(EventCreateRequestDto dto, CancellationToken cancellationToken);
        Task<Event> UpdateAsync(EventUpdateRequestDto dto, int id, CancellationToken cancellationToken);
        Task<Event?> GetAsync(int id, CancellationToken cancellationToken);
    }

    public class EventService(IEventRepository repository) : IEventService
    {
        public async Task<Event> AddAsync(EventCreateRequestDto dto, CancellationToken cancellationToken)
        {
            return await repository.AddEventAsync(dto.Map(), cancellationToken);
        }

        public async Task<Event?> GetAsync(int id, CancellationToken cancellationToken)
        {
            return await repository.GetEventAsync(id, cancellationToken);
        }

        public async Task<Event> UpdateAsync(EventUpdateRequestDto dto, int id, CancellationToken cancellationToken)
        {
            var evt = await repository.GetEventAsync(id, cancellationToken);
            if (evt is null)
                return null;

            return await repository.UpdateEventAsync(dto.Map(evt), cancellationToken);
        }
    }
}
