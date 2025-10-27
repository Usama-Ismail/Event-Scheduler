using Event_Scheduler.Api.Dto;
using Event_Scheduler.Api.Models;

namespace Event_Scheduler.Api.Extensions;

public static class EventMappingExtension
{
    public static Event Map(this EventCreateRequestDto dto)
    {
        return new Event()
        {
            Title = dto.Title,
            Description = dto.Description,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate
        };
    }

    public static EventResponseDto MapToResponse(this Event e)
    {
        return new EventResponseDto
        {
            Id = e.Id,
            Title = e.Title,
            Description = e.Description,
            Status = e.Status,
            StartDate = e.StartDate,
            EndDate = e.EndDate,
            CreatedAt = e.CreatedAt,
            UpdatedAt = e.UpdatedAt
        };
    }

    public static Event Map(this EventUpdateRequestDto dto, Event e)
    {
        if (!string.IsNullOrEmpty(dto.Title))
            e.Title = dto.Title;
        if (!string.IsNullOrEmpty(dto.Description))
            e.Description = dto.Description;
        if (dto.StartDate.HasValue)
            e.StartDate = dto.StartDate.Value;
        if (dto.EndDate.HasValue)
            e.EndDate = dto.EndDate.Value;
        return e;
    }
}

