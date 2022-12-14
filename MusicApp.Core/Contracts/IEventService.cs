using MusicApp.Core.Models.Event;

namespace MusicApp.Core.Contracts
{
    public interface IEventService
    {
        Task AddEvent(EventModel model);

        IEnumerable<EventModel> AdminAllEvents();
    }
}
