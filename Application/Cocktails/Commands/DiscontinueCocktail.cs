using System.Collections.Generic;
using Skol.Domain.Models;
using MediatR;

namespace Skol.Application.Cocktails.Commands
{
    public record DiscontinueCocktail(string Code) : IRequest<Cocktail>;
}