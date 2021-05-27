using System.Collections.Generic;
using Skol.Domain.Models;
using MediatR;

namespace Skol.Application.Cocktails.Commands
{
    public record RebrandCocktail(
        string Code,
        string DisplayName,
        decimal Value,
        string OriginCode,
        string Recipe = null,
        bool ContainsAlcohol = true,
        bool Seasonal = false,
        bool DiscontinueOrigin = false
    ) : IRequest<Cocktail>;
}