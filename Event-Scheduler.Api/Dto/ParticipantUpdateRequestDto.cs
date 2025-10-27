namespace Event_Scheduler.Api.Dto;

public class ParticipantUpdateRequestDto
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public int? EventId { get; set; }
}
