using MediatR;
using Microsoft.EntityFrameworkCore;
using VerticalSliceArchitecture.Data;
using VerticalSliceArchitecture.FeaturesAlt.Games.CrossCutting.Exceptions;

namespace VerticalSliceArchitecture.FeaturesAlt.Games.UpdateGameForPlatform
{
    public class UpdateGameHandler : IRequestHandler<UpdateGameCommand, Unit>
    {
        private readonly AppDbContext _context;

        public UpdateGameHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
        {
            var platform = await _context.Platforms.FirstOrDefaultAsync(p => p.Id == request.PlatformId);

            if (platform == null)
                throw new NoPlatformExistsException(request.PlatformId);

            var game = await _context.Games.FirstOrDefaultAsync(g => g.PlatformId == request.PlatformId && g.Id == request.Id);

            if (game == null)
                throw new NoGameExistsException(request.PlatformId, request.Id);

            game.Name = request.Name;
            game.Publisher = request.Publisher;

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
