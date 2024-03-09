using AutoMapper;
using MediatR;
using VerticalSliceArchitecture.Services;

namespace VerticalSliceArchitecture.Features.Platforms
{
    public class GetAllPlatforms
    {
        public class GetPlatformsQuery : IRequest<IEnumerable<PlatformResult>> { }

        public class PlatformResult
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Manufacturer { get; set; }
        }

        public class Handler : IRequestHandler<GetPlatformsQuery, IEnumerable<PlatformResult>>
        {
            private readonly IRepositoryManager _repositoryManager;
            private readonly IMapper _mapper;

            public Handler(IRepositoryManager serviceManager, IMapper mapper)
            {
                _repositoryManager = serviceManager;
                _mapper = mapper;
            }

            public async Task<IEnumerable<PlatformResult>> Handle(GetPlatformsQuery request, CancellationToken cancellationToken)
            {
                var consoles = await _repositoryManager.Platform.GetAllPlatformsAsync();
                var results = _mapper.Map<IEnumerable<PlatformResult>>(consoles);
                return results;
            }
        }
    }
}
