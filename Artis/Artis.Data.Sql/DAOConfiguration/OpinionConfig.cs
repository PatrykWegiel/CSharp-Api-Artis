using Artis.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artis.Data.Sql.DAOConfiguration
{
    class OpinionConfig : IEntityTypeConfiguration<Opinion>
    {
        public void Configure(EntityTypeBuilder<Opinion> builder)
        {
            builder.Property(c => c.Content).IsRequired();
            builder.Property(c => c.Rate).IsRequired();
            builder.Property(c => c.Banned).HasColumnType("tinyint(1)");

            builder.HasOne(t => t.Author)
                   .WithMany(t => t.UserOpinions)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasForeignKey(t => t.AuthorId);

            builder.HasOne(t => t.RatedUser)
                   .WithMany(t => t.UserRating)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasForeignKey(t => t.RatedUserId);

            builder.ToTable("Opinion");
        }
    }
}
