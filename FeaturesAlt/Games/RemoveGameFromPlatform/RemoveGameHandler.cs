using MediatR;
using Microsoft.EntityFrameworkCore;
using VerticalSliceArchitecture.Data;
using VerticalSliceArchitecture.FeaturesAlt.Games.CrossCutting.Exceptions;

namespace VerticalSliceArchitecture.FeaturesAlt.Games.RemoveGameFromPlatform
{
    public class RemoveGameHandler : IRequestHandler<RemoveGameCommand, Unit>
    {
        private readonly AppDbContext _context;

        public RemoveGameHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RemoveGameCommand request, CancellationToken cancellationToken)
        {
            var platform = await _context.Platforms.FirstOrDefaultAsync(p => p.Id == request.PlatformId);

            if (platform == null)
                throw new NoPlatformExistsException(request.PlatformId);

            var game = await _context.Games.FirstOrDefaultAsync(g => g.PlatformId == request.PlatformId && g.Id == request.GameId);

            if (game == null)
                throw new NoGameExistsException(request.PlatformId, request.GameId);

            _context.Games.Remove(game);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
