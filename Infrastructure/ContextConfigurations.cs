using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Skol.Application;
using Skol.Domain;
using Skol.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Skol.Infrastructure
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Ignore(o => o.StateChanges);
        }
    }

    public class CocktailConfiguration : IEntityTypeConfiguration<Cocktail>
    {
        public void Configure(EntityTypeBuilder<Cocktail> builder)
        {
            builder.Ignore(c => c.StateChanges)
                   .HasQueryFilter(c => !c.Discontinued);
        }
    }
}