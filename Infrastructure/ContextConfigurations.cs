namespace Stocksly.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Stocksly.Domain.Models;

    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Supplier);
        }
    }

    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(s => s.Id);
        }
    }

    public class PurchaseOrderConfiguration : IEntityTypeConfiguration<PurchaseOrder>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrder> builder)
        {
            builder.Ignore(po => po.StateChanges);

            builder.HasKey(po => po.Id);

            builder.Property(po => po.Count);
            builder.Property(po => po.Total);

            builder.Property(po => po.OrderedItems);
            builder
                .HasMany(po => po.OrderedItems).WithOne(poi => poi.PurchaseOrder)
                .IsRequired();

            builder.HasOne(po => po.Supplier);
        }
    }

    public class PurchaseOrderItemConfiguration : IEntityTypeConfiguration<PurchaseOrderItem>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrderItem> builder)
        {
            builder.HasKey(poi => poi.Id);

            builder.Property(poi => poi.Total);

            builder.HasOne(poi => poi.Product);
        }
    }
}