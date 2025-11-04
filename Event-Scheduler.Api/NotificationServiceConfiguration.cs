namespace Event_Scheduler.Api
{
    public class NotificationServiceConfiguration
    {
        public const string Position = "NotificationService";
        public bool IsEnabled { get; set; }
        public bool UseLogger { get; set; }
        public bool UseEmail { get; set; }
    }
}
