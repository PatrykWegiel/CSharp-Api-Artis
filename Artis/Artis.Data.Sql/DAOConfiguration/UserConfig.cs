using Artis.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artis.Data.Sql.DAOConfiguration
{
    class UserConfig : IEntityTypeConfiguration<DAO.User>
    {
        public void Configure(EntityTypeBuilder<DAO.User> builder)
        {
            builder.Property(c => c.BirthDate).IsRequired();
            builder.Property(c => c.RegistrationDate).IsRequired();
            builder.Property(c => c.Email).IsRequired();
            builder.Property(c => c.UserName).IsRequired();
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Surname).IsRequired();
            builder.Property(c => c.Banned).HasColumnType("tinyint(1)");
            builder.Property(c => c.Active).HasColumnType("tinyint(1)");

            builder.ToTable("User");
        }
    }
}
