using System.Text.Json.Serialization;

namespace Skol.Domain.Models
{
    public record OrderItem
    {
        [property: JsonIgnore]
        public int Id { get; init; }
        
        public string Code { get; init; }
        public string DisplayName { get; init; }
        public bool ContainsAlcohol { get; init; } = true;
        public int Quantity { get; init; }
        public decimal Value { get; init; }

        [property: JsonIgnore]
        public int CocktailId { get; init; }

        [property: JsonIgnore]
        public Cocktail Cocktail { get; init; }

        [JsonIgnore]
        public int OrderId { get; init; }

        [JsonIgnore]
        public Order Order { get; init; }
    }
}
