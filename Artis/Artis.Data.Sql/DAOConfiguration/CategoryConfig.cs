using Artis.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artis.Data.Sql.DAOConfiguration
{
    class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.CategoryImage).IsRequired();
            builder.Property(c => c.CategoryName).IsRequired();

            builder.ToTable("Category");
        }
    }
}
