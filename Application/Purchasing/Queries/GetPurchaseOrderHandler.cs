namespace Stocksly.Application.Purchasing.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Stocksly.Domain;
    using Stocksly.Domain.Models;

    public class GetPurchaseOrderHandler : IRequestHandler<GetPurchaseOrder, IEnumerable<PurchaseOrder>>
    {
        private readonly IStockslyContext db;

        public GetPurchaseOrderHandler(IStockslyContext ctx) => db = ctx;

        public async Task<IEnumerable<PurchaseOrder>> Handle(GetPurchaseOrder request, CancellationToken cancellationToken)
        {
            return await db.PurchaseOrders.Include(po => po.OrderedItems).Where(po => po.Id == request.Id).ToListAsync();
        }
    }
}
