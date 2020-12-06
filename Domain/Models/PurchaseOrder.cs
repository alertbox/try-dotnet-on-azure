namespace Stocksly.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json.Serialization;

    public class PurchaseOrder : IStateChangeEnumerator
    {
        public int Id { get; }
        
        public DateTime OrderedTime { get; set; } = DateTime.Now;
        public int Count => OrderedItems.Count();
        public decimal Total => OrderedItems.Sum(oi => oi.Total);

        [JsonIgnore]
        public Supplier Supplier { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }

        public List<PurchaseOrderItem> OrderedItems { get; } = new List<PurchaseOrderItem>();

        [JsonIgnore]
        public List<StateChangeEntry> StateChanges { get; } = new List<StateChangeEntry>();
    }
}
