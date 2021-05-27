using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Skol.Domain.Models;
using MediatR;
using System;

namespace Skol.Application.Cocktails.Commands
{
    public class DiscontinueCocktailHandler : IRequestHandler<DiscontinueCocktail, Cocktail>
    {
        private readonly ISkolContext db;

        public DiscontinueCocktailHandler(ISkolContext ctx) => db = ctx;

        public async Task<Cocktail> Handle(DiscontinueCocktail request, CancellationToken cancellationToken = default)
        {
            Cocktail cocktail = db.Cocktails.Single(c => c.Code.Equals(request.Code));
            cocktail.Discontinued = true;
            cocktail.DiscontinuedDate = DateTime.UtcNow;
            cocktail.StateChanges.Add(new CocktailDiscontinued{ Entity = cocktail });

            await db.SaveChangesAsync(cancellationToken);

            return cocktail;
        }
    }
}