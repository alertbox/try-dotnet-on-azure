namespace Stocksly.Application
{
    using System.Reflection;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) => 
            services.AddMediatR(Assembly.GetExecutingAssembly());
    }
}
