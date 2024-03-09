using AutoMapper;
using VerticalSliceArchitecture.Domain;
using static VerticalSliceArchitecture.Features.Platforms.GetAllPlatforms;

namespace VerticalSliceArchitecture.Features.Platforms
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Platform, PlatformResult>();
        }
    }
}
