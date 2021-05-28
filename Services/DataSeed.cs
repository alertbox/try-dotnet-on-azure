using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Skol.Application;
using Skol.Domain.Models;
using System;

namespace Skol.Services.Seed
{
    public static class DbContextDataSeed
    {
        public static IApplicationBuilder UseSeedData(this IApplicationBuilder app)
        {
            using (IServiceScope scope = app.ApplicationServices.CreateScope())
            {
                ISkolContext db = scope.ServiceProvider.GetRequiredService<ISkolContext>();

                db.Cocktails.AddRange(new Cocktail[]
                {
                new() { Id = 1, Code = "h002", DisplayName = "Hanky Panky", Value = 10.25m},
                new() { Id = 2, Code = "m004", DisplayName = "Pornstar Martini", Value = 16.5m, Discontinued = true, DiscontinuedDate = DateTime.Now.AddMonths(-2) },
                new() { Id = 3, Code = "f075", DisplayName = "French 75", Value = 12.5m },
                new() { Id = 4, Code = "b022", DisplayName = "Brain Damage", Value = 10 },
                new() { Id = 5, Code = "c043", DisplayName = "Corpose Reviver", Value = 14.5m },
                new() { Id = 6, Code = "a043", DisplayName = "Amarula & Eve", Value = 14.5m },
                new() { Id = 7, Code = "b052", DisplayName = "B-52", Value = 14.5m },
                });

                db.SaveChangesAsync();
            }
            return app;
        }
    }

}
