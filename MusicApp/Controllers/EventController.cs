using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Core.Contracts;

namespace MusicApp.Controllers
{
    public class EventController : BaseController
    {
        private readonly IEventService eventService;

        public EventController(IEventService _eventService)
        {
            eventService = _eventService;
        }

        [AllowAnonymous]
        public IActionResult All()
        {
            var model = eventService.AllEvents();
            return View(model);
        }
    }
}
