using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MusicApp.Infrastructure.Data.Entities.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(SeedUsers());
        }

        private List<User> SeedUsers()
        {
            var users = new List<User>();
            var hasher = new PasswordHasher<User>();

            var user = new User()
            {
                Id = "42c8f95a-e61d-445a-bb23-67b2fd181c87",
                UserName = "user@mail.com",
                NormalizedUserName = "USER@MAIL.COM",
                Email = "user@mail.com",
                NormalizedEmail = "USER@MAIL.COM",
                FirstName = "Pesho",
                LastName = "Petrov"
            };

            user.PasswordHash = hasher.HashPassword(user, "user123");
            users.Add(user);

            user = new User()
            {
                Id = "43a3b5b6-a7e5-4949-a539-d7029f18f746",
                UserName = "admin@mail.com",
                NormalizedUserName = "ADMIN@MAIL.COM",
                Email = "admin@mail.com",
                NormalizedEmail = "ADMIN@MAIL.COM",
                FirstName = "Ivan",
                LastName = "Ivanov"
            };

            user.PasswordHash = hasher.HashPassword(user, "admin123");
            users.Add(user);

            return users;
        }
    }
}
