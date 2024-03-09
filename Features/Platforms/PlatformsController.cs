using MediatR;
using Microsoft.AspNetCore.Mvc;
using static VerticalSliceArchitecture.Features.Platforms.GetAllPlatforms;

namespace VerticalSliceArchitecture.Features.Platforms
{
    [ApiController]
    [Route("api/platforms")]
    public class PlatformsController:ControllerBase
    {
        private readonly IMediator _mediator;

        public PlatformsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlatformResult>>> GetPlatformAsync()
        {
            var result = await _mediator.Send(new GetPlatformsQuery());

            return Ok(result);
        }
    }
}
