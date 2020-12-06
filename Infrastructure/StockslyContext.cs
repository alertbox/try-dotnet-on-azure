namespace Stocksly.Infrastructure
{
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Stocksly.Application;
    using Stocksly.Domain;
    using Stocksly.Domain.Models;

    public class StockslyContext : DbContext, IStockslyContext
    {
        private readonly IStateChangeHandler stateHandler;

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }

        public StockslyContext(DbContextOptions opt, IStateChangeHandler handler) : base(opt) => stateHandler = handler;

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            int response = await base.SaveChangesAsync(cancellationToken);
            await BroadcastStateChangesAsync();

            return response;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        private async Task BroadcastStateChangesAsync()
        {
            StateChangeEntry[] entries = ChangeTracker.Entries<IStateChangeEnumerator>()
                .Select(e => e.Entity.StateChanges)
                .SelectMany(e => e).Where(e => !e.Published)
                .ToArray();

            await stateHandler.BroadcastAsync(entries);
        }
    }
}
