using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Skol.Domain.Models;

namespace Skol.Application.Orders.Queries
{
    public class GetOrderHandler : IRequestHandler<GetOrder, IEnumerable<Order>>
    {
        private readonly ISkolContext db;

        public GetOrderHandler(ISkolContext ctx) => db = ctx;

        public async Task<IEnumerable<Order>> Handle(GetOrder request, CancellationToken cancellationToken = default)
        {
            return await db.Orders.AsNoTrackingWithIdentityResolution()
                                  .Include(o => o.Items)
                                  .AsNoTracking()
                                  .Where(o => o.Id.Equals(request.Id))
                                  .ToListAsync(cancellationToken);
        }
    }
}