namespace Stocksly.Application.Inventory.Triggers
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Stocksly.Application.Purchasing.Commands;
    using Stocksly.Domain.Models;

    public class PurchaseOrderReceivedHandler : INotificationHandler<StateChangeNotification<PurchaseOrderReceived>>
    {
        private readonly IStockslyContext db;

        public PurchaseOrderReceivedHandler(IStockslyContext ctx) => db = ctx;

        public async Task Handle(StateChangeNotification<PurchaseOrderReceived> notification, CancellationToken cancellationToken)
        {
            foreach (PurchaseOrderItem poi in notification.StateChangeEntry.Entity.OrderedItems)
            {
                Product p = await db.Products.FirstAsync(p=> p.Id == poi.ProductId);
                p.Stocks = p.Stocks - poi.Quantity;
            }
            await db.SaveChangesAsync(cancellationToken);
        }
    }
}
