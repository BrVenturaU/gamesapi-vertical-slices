using Microsoft.EntityFrameworkCore;
using VerticalSliceArchitecture.Data;
using VerticalSliceArchitecture.Domain;

namespace VerticalSliceArchitecture.Features.Platforms
{
    public class PlatformRepository: IPlatformRepository
    {
        private readonly AppDbContext _context;

        public PlatformRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Platform>> GetAllPlatformsAsync()
        {
            return await _context.Platforms
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<Platform> GetPlatformByIdAsync(int platformId)
        {
            return await _context.Platforms
                .FirstOrDefaultAsync(x => x.Id == platformId);
        }
    }
}
