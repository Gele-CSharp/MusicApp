using Microsoft.AspNetCore.Mvc;
using MusicApp.Core.Contracts;
using MusicApp.Core.Models.Event;

namespace MusicApp.Areas.Admin.Controllers
{
    public class EventController : BaseController
    {
        private readonly IEventService eventService;

        public EventController(IEventService _eventService)
        {
            eventService = _eventService;
        }

        public IActionResult All()
        {
            var model = eventService.AdminAllEvents();
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

            return RedirectToAction(nameof(All), "Event");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await eventService.Delete(id);

            return RedirectToAction(nameof(All), "Event");
        }

        public async Task<IActionResult> Restore(int id)
        {
            await eventService.Restore(id);

            return RedirectToAction(nameof(All), "Event");
        }
    }
}
