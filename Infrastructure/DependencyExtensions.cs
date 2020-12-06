namespace Stocksly.Infrastructure
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Stocksly.Application;

    public static class DependencyExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            return services 
                .AddDbContext<StockslyContext>(opt =>
                    opt
                    //    .UseInMemoryDatabase("StockslyDb")
                       .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                    //    .EnableSensitiveDataLogging()
                    //    .EnableDetailedErrors()
                       .LogTo(Console.WriteLine)
                )
                .AddScoped<IStockslyContext, StockslyContext>()
                .AddScoped<IStateChangeHandler, StateChangeHandler>();
        }
    }
}
