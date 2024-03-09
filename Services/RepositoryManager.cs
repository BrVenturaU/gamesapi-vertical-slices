
using VerticalSliceArchitecture.Data;
using VerticalSliceArchitecture.Features.Games;
using VerticalSliceArchitecture.Features.Platforms;

namespace VerticalSliceArchitecture.Services
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly AppDbContext _context;
        private IPlatformRepository _consoleRepository;
        private IGameRepository _gameRepository;

        public RepositoryManager(AppDbContext context)
        {
            _context = context;
        }

        public IPlatformRepository Platform
        {
            get
            {
                if (_consoleRepository == null)
                    _consoleRepository = new PlatformRepository(_context);

                return _consoleRepository;
            }
        }

        public IGameRepository Game
        {
            get
            {
                if (_gameRepository == null)
                    _gameRepository = new GameRepository(_context);

                return _gameRepository;
            }
        }

        public Task SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
