using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicApp.Infrastructure.Data.Entities.Configuration;
using MusicApp.Infrastructure.Data.Entities;

namespace MusicApp.Data
{
    public class MusicAppDbContext : IdentityDbContext<User>
    {
        public MusicAppDbContext(DbContextOptions<MusicAppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Album> Albums { get; set; } = null!;

        public DbSet<User> User { get; set; } = null!;

        public DbSet<Genre> Genres { get; set; } = null!;

        public DbSet<Comment> Comments { get; set; } = null!;

        public DbSet<Event> Events { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Album>()
                .HasOne(a => a.Genre)
                .WithMany(g => g.Albums)
                .HasForeignKey(a => a.GenreId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new GenreConfiguration());
            builder.ApplyConfiguration(new AlbumConfiguration());
            builder.ApplyConfiguration(new EventConfiguration());

            base.OnModelCreating(builder);
        }
    }
}