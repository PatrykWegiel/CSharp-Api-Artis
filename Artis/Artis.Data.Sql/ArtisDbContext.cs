using Artis.Data.Sql.DAO;
using Artis.Data.Sql.DAOConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Artis.Data.Sql
{
    public class ArtisDbContext : DbContext
    {
        public ArtisDbContext(DbContextOptions<ArtisDbContext> options) : base(options) { }
    
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<DAO.User> User { get; set; }
        public virtual DbSet<DAO.Bid> Bid { get; set; }
        public virtual DbSet<Delivery> Delivery { get; set; }
        public virtual DbSet<DAO.Item> Item { get; set; }
        public virtual DbSet<Opinion> Opinion { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoryConfig());
            builder.ApplyConfiguration(new UserConfig());
            builder.ApplyConfiguration(new BidConfig());
            builder.ApplyConfiguration(new DeliveryConfig());
            builder.ApplyConfiguration(new ItemConfig());
            builder.ApplyConfiguration(new OpinionConfig());
        }
    }
}
