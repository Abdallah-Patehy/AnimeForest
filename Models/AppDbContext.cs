using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Anime_Forest.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        //AppDbContext context; 
        //public AppDbContext(AppDbContext _context)
        //{
        //    context = _context;
        //}
        public DbSet<Anime> Animes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Studio> Studios { get; set; }

        public DbSet<Season> Seasons { get; set; }
        public DbSet<Episode> Episodes { get; set; }

        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Watchlist> Watchlists { get; set; }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<AnimeTag> AnimeTags { get; set; }
        public DbSet<AnimeGenre> AnimeGenres { get; set; }

        public AppDbContext() : base()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ✅ AnimeTag Composite Key
            modelBuilder.Entity<AnimeTag>()
                .HasKey(x => new { x.AnimeId, x.TagId });

            // ✅ AnimeGenre Composite Key
            modelBuilder.Entity<AnimeGenre>()
                .HasKey(x => new { x.AnimeId, x.GenreId });

            // ✅ Favorite Composite Key
            modelBuilder.Entity<Favorite>()
                .HasKey(x => new { x.UserId, x.AnimeId });

            // ✅ Watchlist Composite Key
            modelBuilder.Entity<Watchlist>()
                .HasKey(x => new { x.UserId, x.AnimeId });

            // ✅ Tag unique name (اختياري)
            modelBuilder.Entity<Tag>()
                .HasIndex(x => x.Name)
                .IsUnique();
        }


    }
}