using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VerticalSliceArchitecture.Data;
using VerticalSliceArchitecture.FeaturesAlt.Games.CrossCutting.Exceptions;

namespace VerticalSliceArchitecture.FeaturesAlt.Games.GetAllGamesForPlatform
{
    public class GetGamesForPlatformHandler : IRequestHandler<GetGamesForPlatformQuery, IEnumerable<GetGamesForPlatformResponse>>
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public GetGamesForPlatformHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetGamesForPlatformResponse>> Handle(GetGamesForPlatformQuery request, CancellationToken cancellationToken)
        {
            var platform = await _context.Platforms.FirstOrDefaultAsync(p => p.Id == request.PlatformId);

            if (platform is null)
                throw new NoPlatformExistsException(request.PlatformId);

            var games = await _context.Games.Where(g => g.PlatformId == platform.Id).ToListAsync();
            var result = _mapper.Map<IEnumerable<GetGamesForPlatformResponse>>(games);

            return result;
        }
    }
}
