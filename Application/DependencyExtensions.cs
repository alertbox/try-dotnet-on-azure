using System.Reflection;
using MediatR;
using Skol.Application.Cocktails.Commands;
using Skol.Application.Cocktails.Triggers;
using Skol.Domain.Models;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) =>
            services.AddMediatR(Assembly.GetExecutingAssembly());
    }
}
