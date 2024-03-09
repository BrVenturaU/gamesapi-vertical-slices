using MediatR;

namespace VerticalSliceArchitecture.FeaturesAlt.Games.GetAllGamesForPlatform
{
    public class GetGamesForPlatformQuery : IRequest<IEnumerable<GetGamesForPlatformResponse>>
    {
        public int PlatformId { get; set; }
    }
}
