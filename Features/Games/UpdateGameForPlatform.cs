using AutoMapper;
using MediatR;
using System.Text.Json.Serialization;
using VerticalSliceArchitecture.Features.Games.Exceptions;
using VerticalSliceArchitecture.Services;

namespace VerticalSliceArchitecture.Features.Games
{
    public class UpdateGameForPlatform
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

        public class UpdateGameResult
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Publisher { get; set; }
            public int PlatformId { get; set; }
        }

        public class Handler : IRequestHandler<UpdateGameCommand, Unit>
        {
            private readonly IRepositoryManager _repositoryManager;

            public Handler(IRepositoryManager repositoryManager)
            {
                _repositoryManager = repositoryManager;
            }

            public async Task<Unit> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
            {
                var platform = await _repositoryManager.Platform.GetPlatformByIdAsync(request.PlatformId);

                if (platform == null)
                    throw new NoPlatformExistsException(request.PlatformId);

                var game = await _repositoryManager.Game.GetGameAsync(request.PlatformId, request.Id);

                if (game == null)
                    throw new NoGameExistsException(request.PlatformId, request.Id);

                game.Name = request.Name;
                game.Publisher = request.Publisher;

                await _repositoryManager.SaveAsync();

                return Unit.Value;
            }
        }
    }
}
