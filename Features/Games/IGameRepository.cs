using VerticalSliceArchitecture.Domain;

namespace VerticalSliceArchitecture.Features.Games
{
    public interface IGameRepository
    {
        void AddGameToPlatform(int platformId, Game game);
        void DeleteGame(Game game);
        Task<IEnumerable<Game>> GetAllGamesAsync(int platformId);
        Task<Game> GetGameAsync(int platformId, int gameId);
    }
}
