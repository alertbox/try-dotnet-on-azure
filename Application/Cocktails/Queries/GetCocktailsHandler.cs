using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Skol.Domain.Models;

namespace Skol.Application.Cocktails.Queries
{
    public class GetCocktailsHandler : IRequestHandler<GetCocktails, IEnumerable<Cocktail>>
    {
        private readonly ISkolContext db;

        public GetCocktailsHandler(ISkolContext ctx) => db = ctx;

        public async Task<IEnumerable<Cocktail>> Handle(GetCocktails request, CancellationToken cancellationToken = default)
        {
            int size = request.Size;
            int page = (request.Page - 1) * size;

            return await db.Cocktails.AsNoTrackingWithIdentityResolution().Skip(page).Take(size).ToListAsync(cancellationToken);
        }
    }
}