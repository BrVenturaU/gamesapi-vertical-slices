using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VerticalSliceArchitecture.Data;
using VerticalSliceArchitecture.Services;

namespace VerticalSliceArchitecture.FeaturesAlt.Platforms.GetAllPlatforms
{
    public class GetPlatformsHandler : IRequestHandler<GetPlatformsQuery, IEnumerable<GetPlatformsResponse>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetPlatformsHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetPlatformsResponse>> Handle(GetPlatformsQuery request, CancellationToken cancellationToken)
        {
            var consoles = await _context.Platforms.ToListAsync();
            var results = _mapper.Map<IEnumerable<GetPlatformsResponse>>(consoles);
            return results;
        }
    }
}
