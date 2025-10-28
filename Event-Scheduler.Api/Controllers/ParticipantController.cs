using Event_Scheduler.Api.Dto;
using Event_Scheduler.Api.Extensions;
using Event_Scheduler.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Event_Scheduler.Api.Controllers
{
    [Route("api/participant")]
    [ApiController]
    public class ParticipantController(IParticipantService service) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateParticipantAsync(ParticipantCreateRequestDto dto, CancellationToken cancellationToken)
        {
            var result = await service.AddAsync(dto, cancellationToken);
            return Ok(result.MapToResponse());
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> UpdateParticipantAsync(ParticipantUpdateRequestDto dto, int id, CancellationToken cancellationToken)
        {
            var result = await service.UpdateAsync(dto, id, cancellationToken);
            if (result is null)
                return NotFound($"Participant not found with id {id}");

            return Ok(result.MapToResponse());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetParticipantAsync([FromRoute] int id, CancellationToken cancellationToken)
        {
            var result = await service.GetAsync(id, cancellationToken);
            if (result is null)
                return NotFound($"Participant not found with id {id}");

            return Ok(result.MapToResponse());
        }
    }
}
