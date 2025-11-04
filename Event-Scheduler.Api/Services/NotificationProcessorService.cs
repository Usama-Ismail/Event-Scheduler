using Event_Scheduler.Api.Constants;
using Event_Scheduler.Api.Models;
using Event_Scheduler.Api.Repository;
using Microsoft.Extensions.Options;
using ILogger = Serilog.ILogger;

namespace Event_Scheduler.Api.Services;

public interface INotificationProcessorService
{
    Task ProcessEventsAsync(CancellationToken cancellationToken);
}
public class NotificationProcessorService(IEventRepository eventRepo, IOptions<NotificationServiceConfiguration> options, ILogger logger) : INotificationProcessorService
{
    private readonly NotificationServiceConfiguration _notificationConfiguration = options.Value;
    public async Task ProcessEventsAsync(CancellationToken cancellationToken)
    {
        logger.Information("Event processor started");
        var events = await eventRepo.GetActiveEvents(cancellationToken);
        if (_notificationConfiguration.IsEnabled)
        {
            var eventsToUpdate = new List<Event>();
            foreach (var e in events)
            {
                foreach (var participant in e.Participants)
                {
                    if (_notificationConfiguration.UseLogger)
                        logger.Information($"{e.Title} event is planned for you {participant.Name} at {e.StartDate}");
                    if (_notificationConfiguration.UseEmail)
                    {
                        //If you want to add notification through email that can be added later
                    }
                }

                e.Status = EventConstant.TRIGGERED;
                eventsToUpdate.Add(e);
            }

            if (events.Any())
            {
                await eventRepo.UpdateEventAsync(eventsToUpdate, cancellationToken);
            }
        }
        logger.Information("Event processor finished");
    }
}
