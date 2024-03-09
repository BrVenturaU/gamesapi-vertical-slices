using MediatR;
using Microsoft.AspNetCore.Mvc;
using VerticalSliceArchitecture.Features.Games.Exceptions;
using static VerticalSliceArchitecture.Features.Games.GetAllGamesForPlatform;
using static VerticalSliceArchitecture.Features.Games.RemoveGameFromPlatform;
using static VerticalSliceArchitecture.Features.Games.UpdateGameForPlatform;

namespace VerticalSliceArchitecture.Features.Games
{
    [ApiController]
    [Route("api/platforms/{platformId:int}/games")]
    public class GamesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public GamesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetGamesForPlatform")]
        public async Task<ActionResult<IEnumerable<GamesForPlatformResponse>>> GetGamesForPlatform(int platformId)
        {
            try
            {
                var query = new GetGamesQuery
                {
                    PlatformId = platformId
                };

                var result = await _mediator.Send(query);

                return Ok(result);
            }
            catch (NoPlatformExistsException ex)
            {
                return NotFound(new
                {
                    ex.Message,
                });
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddGame(int platformId, AddGameToPlatform.AddGameCommand command)
        {
            try
            {
                command.PlatformId = platformId;
                var result = await _mediator.Send(command);
                return CreatedAtRoute("GetGamesForPlatform", new { platformId = result.PlatformId }, result);
            }
            catch (NoPlatformExistsException ex)
            {
                return NotFound(new
                {
                    ex.Message
                });
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateGameForPlatform(int platformId, int id, UpdateGameCommand command)
        {
            try
            {
                command.Id = id;
                command.PlatformId = platformId;
                var result = await _mediator.Send(command);
                return NoContent();
            }
            catch (NoPlatformExistsException ex)
            {
                return NotFound(new
                {
                    ex.Message
                });
            }
            catch (NoGameExistsException ex)
            {
                return NotFound(new
                {
                    ex.Message,
                    ex.PlatformId,
                    ex.GameId
                });
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> RemoveGameFromPlatform(int platformId, int id)
        {
            try
            {
                var command = new RemoveGameCommand
                {
                    GameId = id,
                    PlatformId = platformId
                };
                await _mediator.Send(command);
                return NoContent();
            }
            catch (NoPlatformExistsException ex)
            {
                return NotFound(new
                {
                    ex.Message
                });
            }
            catch (NoGameExistsException ex)
            {
                return NotFound(new
                {
                    ex.Message,
                    ex.PlatformId,
                    ex.GameId
                });
            }
        }
    }
}
