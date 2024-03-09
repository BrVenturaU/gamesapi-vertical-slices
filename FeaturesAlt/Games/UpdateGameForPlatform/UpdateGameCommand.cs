using MediatR;
using System.Text.Json.Serialization;

namespace VerticalSliceArchitecture.FeaturesAlt.Games.UpdateGameForPlatform
{
    public class UpdateGameCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        [JsonIgnore]
        public int PlatformId { get; set; }
    }
}
