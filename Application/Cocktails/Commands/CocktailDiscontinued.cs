using System.Collections.Generic;
using Skol.Domain;
using Skol.Domain.Models;
using MediatR;

namespace Skol.Application.Cocktails.Commands
{
    public class CocktailDiscontinued : StateChangeEntry
    {
        public Cocktail Entity { get; init; }
    }
}