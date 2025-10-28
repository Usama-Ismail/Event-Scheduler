using Event_Scheduler.Api.Dto;
using Event_Scheduler.Api.Extensions;
using Event_Scheduler.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Event_Scheduler.Api.Controllers
{
    [Route("api/event")]
    [ApiController]
    public class EventController(IEventService service) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateEventAsync(EventCreateRequestDto dto, CancellationToken cancellationToken)
        {
            var result = await service.AddAsync(dto, cancellationToken);
            return Ok(result.MapToResponse());
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> UpdateEventAsync([FromBody] EventUpdateRequestDto dto, [FromRoute] int id, CancellationToken cancellationToken)
        {
            var result = await service.UpdateAsync(dto, id, cancellationToken);
            if (result is null)
                return NotFound($"Event not found with id {id}");

            return Ok(result.MapToResponse());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventAsync([FromRoute] int id, CancellationToken cancellationToken)
        {
            var result = await service.GetAsync(id, cancellationToken);
            if (result is null)
                return NotFound($"Event not found with id {id}");

            return Ok(result.MapToResponse());
        }
    }
}
