using HouseRentingSystem.Infrastructure.Data.Common;
using MusicApp.Core.Contracts;
using MusicApp.Core.Models.Event;
using MusicApp.Infrastructure.Data.Entities;

namespace MusicApp.Core.Services
{
    public class EventService : IEventService
    {
        private readonly IRepository repository;

        public EventService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task AddEvent(EventModel model)
        {
            var @event = new Event();

            @event.Id = model.Id;
            @event.Artist = model.Artist;
            @event.Date = model.Date;
            @event.Location = model.Location;
            @event.ImageUrl = model.ImageUrl;
            @event.IsActive = model.IsActive;

            await repository.AddAsync<Event>(@event);

            try
            {
                await repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Database failed to save info.", ex);
            }
        }

        public IEnumerable<EventModel> AdminAllEvents()
        {
            return repository
                .AllReadonly<Event>()
                .Where(e=> e.IsActive)
                .Select(e=> new EventModel() 
                {
                    Id = e.Id,
                    Artist = e.Artist,
                    Location = e.Location,
                    ImageUrl = e.ImageUrl,
                    Date = e.Date,
                    IsActive = e.IsActive
                });
        }
    }
}
