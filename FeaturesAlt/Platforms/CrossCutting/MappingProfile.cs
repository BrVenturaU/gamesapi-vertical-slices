using AutoMapper;
using VerticalSliceArchitecture.Domain;
using VerticalSliceArchitecture.FeaturesAlt.Platforms.GetAllPlatforms;

namespace VerticalSliceArchitecture.FeaturesAlt.Platforms.CrossCutting
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Platform, GetPlatformsResponse>();
        }
    }
}
