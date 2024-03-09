using MediatR;

namespace VerticalSliceArchitecture.FeaturesAlt.Platforms.GetAllPlatforms
{
    public class GetPlatformsQuery : IRequest<IEnumerable<GetPlatformsResponse>> { }
}
