using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MusicApp.Infrastructure.Data.Entities.Configuration
{
    internal class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasData(new Event()
            {
                Id = 1,
                Artist = "Лили Иванова",
                Location = "Зала Армеец",
                Date = new DateTime(2022, 12, 1)
            });
        }
    }
}
