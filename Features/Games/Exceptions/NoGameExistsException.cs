namespace VerticalSliceArchitecture.Features.Games.Exceptions
{
    public class NoGameExistsException : Exception
    {
        public NoGameExistsException(int platformId, int gameId) : base($"Game with id: {gameId} doesn't exist for platform id {platformId}")
        {
            PlatformId = platformId;
            GameId = gameId;
        }

        public int PlatformId { get; set; }
        public int GameId { get; set; }
    }
}
