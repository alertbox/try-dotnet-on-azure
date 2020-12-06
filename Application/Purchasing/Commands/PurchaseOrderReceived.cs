namespace Stocksly.Application.Purchasing.Commands
{
    using Stocksly.Domain;
    using Stocksly.Domain.Models;

    public class PurchaseOrderReceived : StateChangeEntry
    {
        public PurchaseOrder Entity { get; }

        public PurchaseOrderReceived(PurchaseOrder entity) => Entity = entity;
    }
}
