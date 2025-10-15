using Event_Scheduler.Api.Repository;
using Microsoft.Extensions.Options;

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
        var events = await eventRepo.GetActiveEvents(cancellationToken);
        if (_notificationConfiguration.IsEnabled)
        {
            foreach (var e in events)
            {
                foreach (var participant in e.Participants)
                {
                    if (_notificationConfiguration.UseLogger)
                        logger.LogInformation($"{e.Title} event is planned for you {participant.Name} at {e.StartDate}");
                    if (_notificationConfiguration.UseEmail)
                    {
                        //Need to fill in the logic 
                    }
                }
            }
        }
    }
}
