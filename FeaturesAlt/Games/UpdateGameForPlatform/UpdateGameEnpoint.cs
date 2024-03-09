using FastEndpoints;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System;
using VerticalSliceArchitecture.FeaturesAlt.Games.CrossCutting.Exceptions;

namespace VerticalSliceArchitecture.FeaturesAlt.Games.UpdateGameForPlatform
{
    public class UpdateGameEnpoint: Endpoint<UpdateGameCommand>
    {
        private readonly IMediator _mediator;

        public UpdateGameEnpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Put("fapi/platforms/{platformId}/games/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(UpdateGameCommand command, CancellationToken ct)
        {
            try
            {
                var platformId = Route<int>("platformId");
                var id = Route<int>("id");
                command.Id = id;
                command.PlatformId = platformId;
                var result = await _mediator.Send(command);
                await SendNoContentAsync();
            }
            catch (NoPlatformExistsException ex)
            {
                await SendNotFoundAsync();
            }
            catch (NoGameExistsException ex)
            {
                await SendNotFoundAsync();
            }
        }
    }
}
