using Microsoft.EntityFrameworkCore;

namespace HallCrawler.Models
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
            // this.Database.Migrate();
            // this.Database.EnsureCreated();
        }

        public virtual DbSet<HallItem> HallItems { get; set; }

        public virtual DbSet<MainWebCrawler> MainWebCrawlers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
