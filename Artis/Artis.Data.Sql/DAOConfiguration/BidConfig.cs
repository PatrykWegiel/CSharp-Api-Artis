using Artis.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artis.Data.Sql.DAOConfiguration
{
    class BidConfig : IEntityTypeConfiguration<DAO.Bid>
    {
        public void Configure(EntityTypeBuilder<DAO.Bid> builder)
        {
            builder.Property(c => c.Amount).IsRequired();
            builder.Property(c => c.CreationDate).IsRequired();

            builder.HasOne(t => t.Item)
                   .WithMany(t => t.Bids)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasForeignKey(t => t.ItemId);

            builder.HasOne(t => t.User)
                   .WithMany(t => t.Bids)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasForeignKey(t => t.UserId);

            builder.ToTable("Bid");

        }
    }
}
