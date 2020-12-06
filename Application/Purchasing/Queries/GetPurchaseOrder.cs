namespace Stocksly.Application.Purchasing.Queries
{
    using System.Collections.Generic;
    using MediatR;
    using Stocksly.Domain.Models;

    public class GetPurchaseOrder : IRequest<IEnumerable<PurchaseOrder>>
    {
        public int Id { get; set; }
    }
}
