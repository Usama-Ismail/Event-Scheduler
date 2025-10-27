using Event_Scheduler.Api.Dto;
using Event_Scheduler.Api.Extensions;
using Event_Scheduler.Api.Models;
using Event_Scheduler.Api.Repository;

namespace Event_Scheduler.Api.Services
{
    public interface IParticipantService
    {
        Task<Participant> AddAsync(ParticipantCreateRequestDto dto, CancellationToken cancellationToken);
        Task<Participant> UpdateAsync(ParticipantUpdateRequestDto dto, int id, CancellationToken cancellationToken);
        Task<Participant?> GetAsync(int id, CancellationToken cancellationToken);
    }
    public class ParticipantService(IParticipantRepository repository) : IParticipantService
    {
        public async Task<Participant> AddAsync(ParticipantCreateRequestDto dto, CancellationToken cancellationToken)
        {
            return await repository.AddAsync(dto.Map(), cancellationToken);
        }

        public async Task<Participant?> GetAsync(int id, CancellationToken cancellationToken)
        {
            return await repository.GetAsync(id, cancellationToken);
        }

        public async Task<Participant> UpdateAsync(ParticipantUpdateRequestDto dto, int id, CancellationToken cancellationToken)
        {
            var participant = await repository.GetAsync(id, cancellationToken);
            if (participant is null)
                return null;

            return await repository.UpdateAsync(dto.Map(participant), cancellationToken);
        }
    }
}
