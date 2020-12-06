namespace Stocksly.Domain.Models
{
    using System;
    using System.Text.Json.Serialization;

    public class PurchaseOrderItem
    {
        public int Id { get; }

        [JsonIgnore]
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductDisplayName { get; set; }

        public int Quantity { get; set; } = 1;
        public decimal UnitPrice { get; set; } = 30;
        public decimal Discount { get; set; } = 0;
        public decimal Total => (Quantity * UnitPrice) - Discount;

        [JsonIgnore]
        public PurchaseOrder PurchaseOrder { get; set; }
        [JsonIgnore]
        public int PurchaseOrderId { get; set; }
    }
}
