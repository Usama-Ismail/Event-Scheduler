namespace Event_Scheduler.Api.Dto;

public class ParticipantResponseDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required EventResponseDto Event { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required DateTime UpdatedAt { get; set; }
}