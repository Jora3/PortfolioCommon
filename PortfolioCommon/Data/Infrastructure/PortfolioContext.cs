using Microsoft.EntityFrameworkCore;
using PortfolioCommon.Data.Entities;

namespace PortfolioCommon.Data.Infrastructure
{
    public class PortfolioContext : DbContext
    {
        public PortfolioContext() {}

        public PortfolioContext(DbContextOptions<PortfolioContext> options) : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"");
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<ReferenceItem> ReferenceItems { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SocialNetwork> SocialNetworks { get; set; }
        public DbSet<Stat> Stats { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkItem> WorkItems { get; set; }
        public DbSet<WorkType> WorkTypes { get; set; }
    }
}
