using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Skol.Application;
using Skol.Infrastructure;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services
                .AddDbContext<SkolContext>(opt =>
                    opt.UseInMemoryDatabase(databaseName: "SkolDb")
                       // .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                       .EnableDetailedErrors()
                       .EnableSensitiveDataLogging()
                       .LogTo(Console.WriteLine), 
                       contextLifetime: ServiceLifetime.Singleton
                )
                .AddSingleton<ISkolContext, SkolContext>()
                .AddSingleton<IStateChangeHandler, StateChangeHandler>();

        }
    }
}
