using VerticalSliceArchitecture.Features.Games;
using VerticalSliceArchitecture.Features.Platforms;

namespace VerticalSliceArchitecture.Services
{
    public interface IRepositoryManager
    {
        IPlatformRepository Platform { get; }
        IGameRepository Game { get; }
        Task SaveAsync();
    }
}
