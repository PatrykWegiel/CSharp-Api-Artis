using Artis.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artis.Data.Sql.DAOConfiguration
{
    class ItemConfig : IEntityTypeConfiguration<DAO.Item>
    {
        public void Configure(EntityTypeBuilder<DAO.Item> builder)
        {
            builder.Property(c => c.ItemName).IsRequired();
            builder.Property(c => c.ItemDescription).IsRequired();
            builder.Property(c => c.Condition).IsRequired();
            builder.Property(c => c.StartingPrice).IsRequired();
            builder.Property(c => c.CreationDate).IsRequired();
            builder.Property(c => c.EndDate).IsRequired();
            builder.Property(c => c.Banned).HasColumnType("tinyint(1)");
            builder.Property(c => c.Visible).HasColumnType("tinyint(1)");

            builder.HasOne(t => t.Category)
                   .WithMany(t => t.Items)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasForeignKey(t => t.CategoryId);

            builder.HasOne(t => t.User)
                   .WithMany(t => t.Items)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasForeignKey(t => t.UserId);

            builder.ToTable("Item");
        }
    }
}
