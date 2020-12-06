namespace Stocksly.Application.Inventory.Queries
{
    using System.Collections.Generic;
    using MediatR;
    using Stocksly.Domain.Models;

    public class GetProducts : IRequest<IEnumerable<Product>>
    {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 30;
    }
}
