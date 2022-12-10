using Microsoft.AspNetCore.Mvc;
using MusicApp.Core.Contracts;

namespace MusicApp.Controllers
{
    public class StatisticsController : BaseController
    {
        private readonly IStatisticsService statisticsService;

        public StatisticsController(IStatisticsService _statisticsService)
        {
            statisticsService = _statisticsService;
        }

        public async Task<IActionResult> Top3()
        {
            var model = await statisticsService.Top3();
            return View(model);
        }
    }
}
