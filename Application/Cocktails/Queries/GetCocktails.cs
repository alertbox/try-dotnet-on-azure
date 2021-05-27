using System.Collections.Generic;
using MediatR;
using Skol.Domain.Models;

namespace Skol.Application.Cocktails.Queries
{
    public record GetCocktails(int Page = 1, int Size = 30) : IRequest<IEnumerable<Cocktail>>;
}