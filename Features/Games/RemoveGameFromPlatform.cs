using MediatR;
using System.Text.Json.Serialization;
using VerticalSliceArchitecture.Features.Games.Exceptions;
using VerticalSliceArchitecture.Services;

namespace VerticalSliceArchitecture.Features.Games
{
    public class RemoveGameFromPlatform
    {
        public class RemoveGameCommand : IRequest<Unit>
        {
            [JsonIgnore]
            public int PlatformId { get; set; }
            [JsonIgnore]
            public int GameId { get; set; }
        }

        public class Handler : IRequestHandler<RemoveGameCommand, Unit>
        {
            private readonly IRepositoryManager _repositoryManager;

            public Handler(IRepositoryManager serviceManager)
            {
                _repositoryManager = serviceManager;
            }

            public async Task<Unit> Handle(RemoveGameCommand request, CancellationToken cancellationToken)
            {
                var platform = await _repositoryManager.Platform.GetPlatformByIdAsync(request.PlatformId);

                if (platform == null)
                    throw new NoPlatformExistsException(request.PlatformId);

                var game = await _repositoryManager.Game.GetGameAsync(request.PlatformId, request.GameId);

                if (game == null)
                    throw new NoGameExistsException(request.PlatformId, request.GameId);

                _repositoryManager.Game.DeleteGame(game);

                await _repositoryManager.SaveAsync();

                return Unit.Value;
            }
        }
    }
}
