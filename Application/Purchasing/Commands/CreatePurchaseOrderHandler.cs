namespace Stocksly.Application.Purchasing.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Stocksly.Domain;
    using Stocksly.Domain.Models;

    public class CreatePurchaseOrderHandler : IRequestHandler<CreatePurchaseOrder, int>
    {
        private readonly IStockslyContext db;

        public CreatePurchaseOrderHandler(IStockslyContext ctx) => db = ctx;

        public async Task<int> Handle(CreatePurchaseOrder request, CancellationToken cancellationToken)
        {
            Supplier supplier = await db.Suppliers.SingleAsync(s => s.Id == request.SupplierId);

            Product[] products = await db.Products.Where(p => p.SupplierId == request.SupplierId && !p.Discontinued).ToArrayAsync();

            PurchaseOrder po = new PurchaseOrder
            {
                Supplier = supplier,
                SupplierName = supplier.Name,
            };

            foreach (CreatePurchaseOrder.OrderItem oi in request.OrderedItems)
            {
                Product p = products.First(p => p.Code == oi.ProductCode);

                po.OrderedItems.Add(new PurchaseOrderItem
                {
                    Product = p,
                    ProductCode = p.Code,
                    ProductDisplayName = p.DisplayName,

                    UnitPrice = p.UnitPrice,
                    Quantity = oi.Quantity,
                });
            }
            db.PurchaseOrders.Add(po);
            po.StateChanges.Add(new PurchaseOrderReceived(po));

            await db.SaveChangesAsync(cancellationToken);

            return po.Id;
        }
    }
}
