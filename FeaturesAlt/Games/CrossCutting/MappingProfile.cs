using AutoMapper;
using VerticalSliceArchitecture.Domain;
using VerticalSliceArchitecture.FeaturesAlt.Games.AddGameToPlatform;
using VerticalSliceArchitecture.FeaturesAlt.Games.GetAllGamesForPlatform;

namespace VerticalSliceArchitecture.FeaturesAlt.Games.CrossCutting
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Game, GetGamesForPlatformResponse>();
            CreateMap<Game, AddGameResponse>();
        }
    }
}
