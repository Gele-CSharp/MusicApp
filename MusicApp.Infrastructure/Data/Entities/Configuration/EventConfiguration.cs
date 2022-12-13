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
                ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.eventim.bg%2Fbg%2Fartist%2Flili-ivanova-2%2Fprofile.html&psig=AOvVaw3IDtRNU1-18kn24xJVnSN8&ust=1671022386647000&source=images&cd=vfe&ved=2ahUKEwj53bTP0fb7AhWRYPEDHUnCBqAQjRx6BAgAEAo",
                Location = "Зала Армеец",
                Date = new DateTime(2022, 12, 4, 20, 0, 0)
            });
        }
    }
}
