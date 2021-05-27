using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Skol.Domain.Models;
using MediatR;
using System;
using Microsoft.EntityFrameworkCore;

namespace Skol.Application.Cocktails.Commands
{
    public class RebrandCocktailHandler : IRequestHandler<RebrandCocktail, Cocktail>
    {
        private readonly ISkolContext db;

        public RebrandCocktailHandler(ISkolContext ctx) => db = ctx;

        public async Task<Cocktail> Handle(RebrandCocktail request, CancellationToken cancellationToken = default)
        {
            Cocktail origin = db.Cocktails.AsNoTrackingWithIdentityResolution().Single(c => c.Code.Equals(request.OriginCode));
            Cocktail cocktail = new()
            {
                Code = request.Code,
                DisplayName = request.DisplayName,
                Recipe = request.Recipe,
                Value = request.Value,
                ContainsAlcohol = request.ContainsAlcohol,
                Seasonal = request.Seasonal,

                OriginId = origin.Id,
                OriginCode = origin.Code,
                OriginDisplayName = origin.DisplayName,
            };
            cocktail.StateChanges.Add(new CocktailRebranded{ Entity = cocktail, Origin = origin, OriginDiscontinued = request.DiscontinueOrigin });
            db.Cocktails.Add(cocktail);

            await db.SaveChangesAsync(cancellationToken);

            return cocktail;
        }
    }
}