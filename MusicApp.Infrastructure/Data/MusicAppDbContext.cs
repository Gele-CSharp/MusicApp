using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MusicApp.Data
{
    public class MusicAppDbContext : IdentityDbContext
    {
        public MusicAppDbContext(DbContextOptions<MusicAppDbContext> options)
            : base(options)
        {
        }
    }
}