using FastEndpoints;
using MediatR;

namespace VerticalSliceArchitecture.FeaturesAlt.Platforms.GetAllPlatforms
{
    public class GetPlatformsEndpoint: EndpointWithoutRequest<IEnumerable<GetPlatformsResponse>>
    {
        private readonly IMediator _mediator;

        public GetPlatformsEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Get("fapi/platforms");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var result = await _mediator.Send(new GetPlatformsQuery());

            await SendAsync(result);
        }
    }
}
