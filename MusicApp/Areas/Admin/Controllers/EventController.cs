using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MusicApp.Core.Contracts;
using MusicApp.Core.Models.Event;
using static MusicApp.Infrastructure.Data.DataConstants.Event;

namespace MusicApp.Areas.Admin.Controllers
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

        public IActionResult All()
        {
            var model = cache.Get<IEnumerable<EventModel>>(EventsCacheKey);

            if (model == null)
            {
                model = eventService.AdminAllEvents().ToList();
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
                cache.Set(EventsCacheKey, model, cacheOptions);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new EventModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventModel model)
        {
            await eventService.AddEvent(model);
            cache.Remove(EventsCacheKey);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await eventService.EventDetailsToEdit(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EventModel model)
        {
            await eventService.Edit(model);
            cache.Remove(EventsCacheKey);

            return RedirectToAction(nameof(All), "Event");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await eventService.Delete(id);
            cache.Remove(EventsCacheKey);

            return RedirectToAction(nameof(All), "Event");
        }

        public async Task<IActionResult> Restore(int id)
        {
            await eventService.Restore(id);
            cache.Remove(EventsCacheKey);

            return RedirectToAction(nameof(All), "Event");
        }
    }
}
