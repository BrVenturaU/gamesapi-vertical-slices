using FastEndpoints;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using VerticalSliceArchitecture.FeaturesAlt.Games.AddGameToPlatform;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using VerticalSliceArchitecture.FeaturesAlt.Games.CrossCutting.Exceptions;

namespace VerticalSliceArchitecture.FeaturesAlt.Games.GetAllGamesForPlatform
{
    public class GetGamesForPlatformEndpoint: EndpointWithoutRequest<IEnumerable<GetGamesForPlatformResponse>>
    {
        private readonly IMediator _mediator;

        public GetGamesForPlatformEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Get("fapi/platforms/{platformId}/games");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            try
            {
                var platformId = Route<int>("platformId");
                var query = new GetGamesForPlatformQuery
                {
                    PlatformId = platformId
                };
                var result = await _mediator.Send(query);
                await SendAsync(result);
            }
            catch (NoPlatformExistsException ex)
            {
                await SendNotFoundAsync();
            }
        }
    }
}
