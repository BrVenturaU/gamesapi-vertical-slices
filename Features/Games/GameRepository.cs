using Microsoft.EntityFrameworkCore;
using VerticalSliceArchitecture.Data;
using VerticalSliceArchitecture.Domain;

namespace VerticalSliceArchitecture.Features.Games
{
    public class GameRepository : IGameRepository
    {
        private readonly AppDbContext _context;

        public GameRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddGameToPlatform(int platformId, Game game)
        {
            game.PlatformId = platformId;

            _context.Games.Add(game);
        }

        public void DeleteGame(Game game)
        {
            _context.Games.Remove(game);
        }

        public async Task<IEnumerable<Game>> GetAllGamesAsync(int platformId)
        {
            return await _context.Games
                .Where(x => x.PlatformId == platformId)
                .ToListAsync();
        }

        public async Task<Game> GetGameAsync(int platformId, int gameId)
        {
            return await _context.Games
                .FirstOrDefaultAsync(x => x.PlatformId == platformId && x.Id == gameId);
        }
    }
}
