using VerticalSliceArchitecture.Domain;

namespace VerticalSliceArchitecture.Features.Platforms
{
    public interface IPlatformRepository
    {
        Task<IEnumerable<Platform>> GetAllPlatformsAsync();
        Task<Platform> GetPlatformByIdAsync(int platform);
    }
}
