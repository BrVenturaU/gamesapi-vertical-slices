using FastEndpoints;
using MediatR;
using VerticalSliceArchitecture.FeaturesAlt.Games.CrossCutting.Exceptions;

namespace VerticalSliceArchitecture.FeaturesAlt.Games.AddGameToPlatform
{
    public class AddGameEndpoint: Endpoint<AddGameCommand, AddGameResponse>
    {
        private readonly IMediator _mediator;

        public AddGameEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }
        public override void Configure()
        {
            Post("fapi/platforms/{platformId}/games");
            AllowAnonymous();
        }

        public override async Task HandleAsync(AddGameCommand command, CancellationToken ct)
        {
            try
            {
                var platformId = Route<int>("platformId");
                command.PlatformId = platformId;
                var result = await _mediator.Send(command);
                await SendCreatedAtAsync<AddGameEndpoint>(new { platformId = result.PlatformId }, result);
            }
            catch (NoPlatformExistsException ex)
            {
                await SendNotFoundAsync();
            }
        }
    }
}
