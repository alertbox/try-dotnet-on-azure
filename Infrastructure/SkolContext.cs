using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Skol.Application;
using Skol.Domain;
using Skol.Domain.Models;

namespace Skol.Infrastructure
{
    public class SkolContext : DbContext, ISkolContext
    {
        private readonly IStateChangeHandler stateHandler;

        public DbSet<Cocktail> Cocktails { get; init; }
        public DbSet<Order> Orders { get; init; }
        public DbSet<OrderItem> OrderItems { get; init; }

        public SkolContext(DbContextOptions opt, IStateChangeHandler handler) : base(opt) => stateHandler = handler;

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
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
                                                      .SelectMany(e => e)
                                                      .Where(e => !e.Published)
                                                      .ToArray();

            await stateHandler.BroadcastAsync(entries);
        }
    }
}
