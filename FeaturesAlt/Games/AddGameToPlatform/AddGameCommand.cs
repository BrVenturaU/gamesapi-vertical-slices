using MediatR;
using System.Text.Json.Serialization;

namespace VerticalSliceArchitecture.FeaturesAlt.Games.AddGameToPlatform
{
    public class AddGameCommand : IRequest<AddGameResponse>
    {
        public string Name { get; set; }
        public string Publisher { get; set; }
        [JsonIgnore]
        public int PlatformId { get; set; }
    }
}