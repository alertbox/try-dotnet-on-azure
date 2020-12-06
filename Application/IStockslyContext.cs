namespace Stocksly.Application
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Stocksly.Domain.Models;
    public interface IStockslyContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Supplier> Suppliers { get; set; }
        DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
