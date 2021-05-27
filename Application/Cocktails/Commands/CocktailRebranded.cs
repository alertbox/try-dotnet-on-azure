using System.Collections.Generic;
using Skol.Domain;
using Skol.Domain.Models;
using MediatR;

namespace Skol.Application.Cocktails.Commands
{
    public class CocktailRebranded : StateChangeEntry
    {
        public Cocktail Entity { get; init; }
        public Cocktail Origin { get; init; }
        public bool OriginDiscontinued { get; init; } = false;
    }
}