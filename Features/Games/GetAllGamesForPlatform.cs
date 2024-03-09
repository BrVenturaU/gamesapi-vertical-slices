using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VerticalSliceArchitecture.Features.Games.Exceptions;
using VerticalSliceArchitecture.Services;

namespace VerticalSliceArchitecture.Features.Games
{
    public class GetAllGamesForPlatform
    {
        public class GetGamesQuery : IRequest<IEnumerable<GamesForPlatformResponse>>
        {
            public int PlatformId { get; set; }
        }

        public class GamesForPlatformResponse
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Publisher { get; set; }
        }

        public class Handler : IRequestHandler<GetGamesQuery, IEnumerable<GamesForPlatformResponse>>
        {
            private readonly IMapper _mapper;
            private readonly IRepositoryManager _repositoryManager;

            public Handler(IRepositoryManager repositoryManager, IMapper mapper)
            {
                _repositoryManager = repositoryManager;
                _mapper = mapper;
            }

            public async Task<IEnumerable<GamesForPlatformResponse>> Handle(GetGamesQuery request, CancellationToken cancellationToken)
            {
                var platform = await _repositoryManager.Platform.GetPlatformByIdAsync(request.PlatformId);

                if (platform is null)
                    throw new NoPlatformExistsException(request.PlatformId);

                var games = await _repositoryManager.Game.GetAllGamesAsync(platform.Id);
                var result = _mapper.Map<IEnumerable<GamesForPlatformResponse>>(games);
                return result;
            }
        }
    }
}
