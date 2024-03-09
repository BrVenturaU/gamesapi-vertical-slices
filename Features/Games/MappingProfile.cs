using AutoMapper;
using VerticalSliceArchitecture.Domain;
using static VerticalSliceArchitecture.Features.Games.AddGameToPlatform;
using static VerticalSliceArchitecture.Features.Games.GetAllGamesForPlatform;

namespace VerticalSliceArchitecture.Features.Games
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Game, GamesForPlatformResponse>();
            CreateMap<Game, GameResult>();
        }
    }
}
