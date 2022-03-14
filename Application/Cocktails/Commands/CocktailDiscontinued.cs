using Skol.Domain;
using Skol.Domain.Models;

namespace Skol.Application.Cocktails.Commands
{
    public class CocktailDiscontinued : StateChangeEntry
    {
        public Cocktail Entity { get; init; }
    }
}