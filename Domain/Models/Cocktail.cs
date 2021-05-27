using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Skol.Domain.Models
{
    public record Cocktail : IStateChangeEnumerator
    {
        [property: JsonIgnore]
        public int Id { get; init; }

        public string Code { get; init; }
        public string DisplayName { get; init; }
        public string Recipe { get; set; }
        public decimal Value { get; set; } = 0;
        public bool ContainsAlcohol { get; set; } = true;
        public bool Seasonal { get; set; } = false;

        [property: JsonIgnore]
        public int? OriginId { get; set; }
        public string OriginCode { get; set; }
        public string OriginDisplayName { get; set; }

        [property: JsonIgnore]
        public Cocktail Origin { get; set; }

        public bool Discontinued { get; set; } = false;
        public DateTime? DiscontinuedDate { get; set; } = null;
        
        [property: JsonIgnore]
        public List<StateChangeEntry> StateChanges { get; init; } = new List<StateChangeEntry>();
    };
}
