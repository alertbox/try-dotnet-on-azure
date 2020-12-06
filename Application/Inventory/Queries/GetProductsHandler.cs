namespace Stocksly.Application.Inventory.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Stocksly.Domain;
    using Stocksly.Domain.Models;

    public class GetProductsHandler : IRequestHandler<GetProducts, IEnumerable<Product>>
    {
        private readonly IStockslyContext db;

        public GetProductsHandler(IStockslyContext ctx) => db = ctx;

        public async Task<IEnumerable<Product>> Handle(GetProducts request, CancellationToken cancellationToken)
        {
            int size = request.Size;
            int page = (request.Page - 1) * size;

            return await db.Products.Skip(page).Take(size).ToListAsync(cancellationToken);
        }
    }
}
