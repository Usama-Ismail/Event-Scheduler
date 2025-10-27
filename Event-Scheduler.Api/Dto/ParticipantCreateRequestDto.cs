namespace Event_Scheduler.Api.Dto;

public class ParticipantCreateRequestDto
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int EventId { get; set; }
}
