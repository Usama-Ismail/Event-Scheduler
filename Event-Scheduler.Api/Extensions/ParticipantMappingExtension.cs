using Event_Scheduler.Api.Dto;
using Event_Scheduler.Api.Models;

namespace Event_Scheduler.Api.Extensions
{
    public static class ParticipantMappingExtension
    {
        public static Participant Map(this ParticipantCreateRequestDto dto)
        {
            return new Participant
            {
                Name = dto.Name,
                Email = dto.Email,
                EventId = dto.EventId,
                CreatedAt = DateTime.Now
            };
        }

        public static Participant Map(this ParticipantUpdateRequestDto dto, Participant p)
        {
            if (!string.IsNullOrEmpty(dto.Name))
                p.Name = dto.Name;
            if (!string.IsNullOrEmpty(dto.Email))
                p.Email = dto.Email;
            if (dto.EventId.HasValue)
                p.EventId = dto.EventId.Value;
            return p;
        }

        public static ParticipantResponseDto Map(this Participant p)
        {
            return new ParticipantResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Email = p.Email,
                Event = p.Event.MapToResponse(),
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt
            };
        }
    }
}
