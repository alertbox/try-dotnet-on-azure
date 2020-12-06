namespace Stocksly.Domain.Models
{
    using System;
    using System.Text.Json.Serialization;

    public class Product
    {
        public int Id { get; }
        
        public string Code { get; set; }
        public string DisplayName { get; set; }
        public int ReorderLevel { get; set; } = 100;
        public int Stocks { get; set; } = 200;
        public decimal UnitPrice { get; set; } = 30;
        public bool Discontinued { get; set; } = false;
        public DateTime? DiscontinuedDate { get; set; }

        [JsonIgnore]
        public Supplier Supplier { get; set; }
        public int SupplierId { get; set; }
    }
}
