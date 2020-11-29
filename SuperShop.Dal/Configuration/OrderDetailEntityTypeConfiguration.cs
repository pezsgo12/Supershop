using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperShop.Model;

namespace SuperShop.Dal.Configuration
{
    internal class OrderDetailEntityTypeConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.Property(p => p.Price).HasColumnType("money");
        }
    }
}