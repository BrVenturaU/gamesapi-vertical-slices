using MediatR;
using System.Text.Json.Serialization;

namespace VerticalSliceArchitecture.FeaturesAlt.Games.RemoveGameFromPlatform
{
    public class RemoveGameCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public int PlatformId { get; set; }
        [JsonIgnore]
        public int GameId { get; set; }
    }
}
