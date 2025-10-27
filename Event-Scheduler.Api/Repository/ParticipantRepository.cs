using Event_Scheduler.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Event_Scheduler.Api.Repository
{
    public interface IParticipantRepository
    {
        Task<Participant> AddAsync(Participant participant, CancellationToken cancellationToken);
        Task<Participant> UpdateAsync(Participant participant, CancellationToken cancellationToken);
        Task<Participant?> GetAsync(int id, CancellationToken cancellationToken);
    }
    public class ParticipantRepository(ApplicationDbContext context) : IParticipantRepository
    {
        public async Task<Participant> AddAsync(Participant participant, CancellationToken cancellationToken)
        {
            await context.Participants.AddAsync(participant);
            await context.SaveChangesAsync(cancellationToken);
            return participant;
        }

        public async Task<Participant?> GetAsync(int id, CancellationToken cancellationToken)
        {
            return await context.Participants
                .Include(i => i.Event)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<Participant> UpdateAsync(Participant participant, CancellationToken cancellationToken)
        {
            context.Participants.Update(participant);
            await context.SaveChangesAsync(cancellationToken);
            return participant;
        }
    }
}
