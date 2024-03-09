using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json.Serialization;
using VerticalSliceArchitecture.Domain;
using VerticalSliceArchitecture.Features.Games.Exceptions;
using VerticalSliceArchitecture.Services;

namespace VerticalSliceArchitecture.Features.Games
{
    public class AddGameToPlatform
    {
        public class AddGameCommand : IRequest<GameResult>
        {
            public string Name { get; set; }
            public string Publisher { get; set; }
            [JsonIgnore]
            public int PlatformId { get; set; }
        }

        public class GameResult
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Publisher { get; set; }
            public int PlatformId { get; set; }
        }

        //Handler
        public class Handler : IRequestHandler<AddGameCommand, GameResult>
        {
            private readonly IRepositoryManager _repositoryManager;
            private readonly IMapper _mapper;
            public Handler(IRepositoryManager serviceManager, IMapper mapper)
            {
                _repositoryManager = serviceManager;
                _mapper = mapper;
            }

            public async Task<GameResult> Handle(AddGameCommand request, CancellationToken cancellationToken)
            {
                var platform = await _repositoryManager.Platform.GetPlatformByIdAsync(request.PlatformId);
                if (platform == null)
                    throw new NoPlatformExistsException(request.PlatformId);

                var game = new Game()
                {
                    Name = request.Name,
                    Publisher = request.Publisher,
                    PlatformId = request.PlatformId
                };

                _repositoryManager.Game.AddGameToPlatform(request.PlatformId, game);
                await _repositoryManager.SaveAsync();
                var result = _mapper.Map<GameResult>(game);
                return result;
            }
        }
    }
}
