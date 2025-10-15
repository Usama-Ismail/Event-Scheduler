using Event_Scheduler.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Event_Scheduler.Api.Repository;

public interface IEventRepository
{
    Task<List<Event>> GetActiveEvents(CancellationToken cancellationToken);
    Task<Event> AddEventAsync(Event entity, CancellationToken cancellationToken);
}
public class EventRepository(ApplicationDbContext context) : IEventRepository
{
    public async Task<Event> AddEventAsync(Event entity, CancellationToken cancellationToken)
    {
        await context.Events.AddAsync(entity);
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<List<Event>> GetActiveEvents(CancellationToken cancellationToken)
    {
        var dateTimeNow = DateTime.Now;
        var upcoming = dateTimeNow.AddMinutes(10);

        return await context.Events
               .Where(x => x.StartDate >= dateTimeNow && x.StartDate <= upcoming)
               .Include(x => x.Participants)
               .ToListAsync(cancellationToken);
    }
}
