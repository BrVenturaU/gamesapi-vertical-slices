using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VerticalSliceArchitecture.Data;
using VerticalSliceArchitecture.Domain;
using VerticalSliceArchitecture.FeaturesAlt.Games.CrossCutting.Exceptions;

namespace VerticalSliceArchitecture.FeaturesAlt.Games.AddGameToPlatform
{
    public class AddGameHandler : IRequestHandler<AddGameCommand, AddGameResponse>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public AddGameHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AddGameResponse> Handle(AddGameCommand request, CancellationToken cancellationToken)
        {
            var platform = await _context.Platforms.FirstOrDefaultAsync(p => p.Id == request.PlatformId);
            if (platform == null)
                throw new NoPlatformExistsException(request.PlatformId);

            var game = new Game()
            {
                Name = request.Name,
                Publisher = request.Publisher,
                PlatformId = request.PlatformId
            };

            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<AddGameResponse>(game);
            return result;
        }
    }
}
