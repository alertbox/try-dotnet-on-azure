using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Skol.Domain.Models;

namespace Skol.Application
{
    public interface ISkolContext
    {
        DbSet<Cocktail> Cocktails { get; init; }
        DbSet<Order> Orders { get; init; }
        DbSet<OrderItem> OrderItems { get; init; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
