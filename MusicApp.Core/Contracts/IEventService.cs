using MusicApp.Core.Models.Event;

namespace MusicApp.Core.Contracts
{
    public interface IEventService
    {
        Task AddEvent(EventModel model);

        IEnumerable<EventModel> AdminAllEvents();

        IEnumerable<EventModel> AllEvents();

        Task<EventModel> EventDetailsToEdit(int eventId);

        Task Edit(EventModel model);

        Task Delete(int id);

        Task Restore(int id);
    }
}
