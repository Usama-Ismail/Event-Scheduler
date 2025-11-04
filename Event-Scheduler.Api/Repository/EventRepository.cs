using Event_Scheduler.Api.Constants;
using Event_Scheduler.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Event_Scheduler.Api.Repository;

public interface IEventRepository
{
    /// <summary>
    /// This method get the active events currently defaulted to get events that are due for next 10 minutes
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<Event>> GetActiveEvents(CancellationToken cancellationToken, int minutes = 10);
    Task<Event> AddEventAsync(Event entity, CancellationToken cancellationToken);
    Task<Event?> GetEventAsync(int id, CancellationToken cancellationToken);
    Task<Event> UpdateEventAsync(Event entity, CancellationToken cancellationToken);
}
public class EventRepository(ApplicationDbContext context) : IEventRepository
{
    public async Task<Event> AddEventAsync(Event entity, CancellationToken cancellationToken)
    {
        await context.Events.AddAsync(entity);
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<List<Event>> GetActiveEvents(CancellationToken cancellationToken, int minutes = 10)
    {
        var dateTimeNow = DateTime.Now;
        var upcoming = dateTimeNow.AddMinutes(minutes);

        return await context.Events
               .Where(x => x.StartDate >= dateTimeNow && x.StartDate <= upcoming)
               .Where(x => x.Status == EventConstant.WAITING)
               .Include(x => x.Participants)
               .ToListAsync(cancellationToken);
    }

    public async Task<Event?> GetEventAsync(int id, CancellationToken cancellationToken)
    {
        return await context.Events.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<Event> UpdateEventAsync(Event entity, CancellationToken cancellationToken)
    {
        context.Events.Update(entity);
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }
}
