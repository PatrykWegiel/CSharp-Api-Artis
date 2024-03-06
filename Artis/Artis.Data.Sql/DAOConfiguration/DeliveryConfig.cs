using Artis.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artis.Data.Sql.DAOConfiguration
{
    class DeliveryConfig : IEntityTypeConfiguration<Delivery>
    {
        public void Configure(EntityTypeBuilder<Delivery> builder)
        {
            builder.Property(c => c.BuldingNumber).IsRequired();
            builder.Property(c => c.PostalCode).IsRequired();
            builder.Property(c => c.Street).IsRequired();
            builder.Property(c => c.City).IsRequired();

            builder.HasOne(t => t.Bid)
                   .WithOne(t => t.Delivery)
                   .HasForeignKey<Delivery>(t => t.BidId);

            builder.ToTable("Delivery");
        }
    }
}
