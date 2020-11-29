using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperShop.Model;

namespace SuperShop.Dal.Configuration
{
    internal class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.UnitPrice).HasColumnType("money");
        }
    }
}