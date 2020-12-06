namespace Stocksly.Application.Purchasing.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using MediatR;

    public class CreatePurchaseOrder : IRequest<int>
    {
        public class OrderItem
        {
            public string ProductCode { get; set; }
            public int Quantity { get; set; }
        }

        public int SupplierId { get; set; }
        public IEnumerable<OrderItem> OrderedItems => new List<OrderItem>();
    }
}
