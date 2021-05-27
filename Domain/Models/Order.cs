using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Skol.Domain.Models
{
    public record Order : IStateChangeEnumerator
    {
        [property: JsonIgnore]
        public int Id { get; init; }
        
        public bool ContainsAlcohol => Items.Any(i => i.ContainsAlcohol);
        public int Quantity => Items.Sum(i => i.Quantity);
        public decimal Discount { get; init; } = 0;
        public decimal Value => Items.Sum(i => i.Value) - Discount;
        public DateTime PlacedAsOf => DateTime.UtcNow;
        public List<OrderItem> Items { get; init; } = new List<OrderItem>();

        [JsonIgnore]
        public List<StateChangeEntry> StateChanges { get; init; } = new List<StateChangeEntry>();
    }
}
