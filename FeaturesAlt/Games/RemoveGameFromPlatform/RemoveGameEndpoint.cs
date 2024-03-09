using FastEndpoints;
using MediatR;
using System;
using VerticalSliceArchitecture.FeaturesAlt.Games.CrossCutting.Exceptions;

namespace VerticalSliceArchitecture.FeaturesAlt.Games.RemoveGameFromPlatform
{
    public class RemoveGameEndpoint: EndpointWithoutRequest
    {
        private readonly IMediator _mediator;

        public RemoveGameEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Delete("fapi/platforms/{platformId}/games/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            try
            {
                var platformId = Route<int>("platformId");
                var id = Route<int>("id");
                var command = new RemoveGameCommand
                {
                    GameId = id,
                    PlatformId = platformId
                };
                await _mediator.Send(command);
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
