using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MusicApp.Core.Contracts;
using MusicApp.Core.Models.Event;
using static MusicApp.Infrastructure.Data.DataConstants.Event;

namespace MusicApp.Controllers
{
    public class EventController : BaseController
    {
        private readonly IEventService eventService;
        private readonly IMemoryCache cache;

        public EventController(IEventService _eventService,
                               IMemoryCache _cache)
        {
            eventService = _eventService;
            cache = _cache;
        }

        [AllowAnonymous]
        public IActionResult All()
        {
            var model = cache.Get<IEnumerable<EventModel>>(EventsCacheKey);

            if (model == null)
            {
                model = eventService.AllEvents().ToList();
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
                cache.Set(EventsCacheKey, model, cacheOptions);
            }

            return View(model);
        }
    }
}
