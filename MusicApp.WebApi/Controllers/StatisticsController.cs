using Microsoft.AspNetCore.Mvc;
using MusicApp.Core.Contracts;
using MusicApp.Core.Models.Statistics;

namespace MusicApp.WebApi.Controllers
{
    [Route("api/statistics")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService statisticsService;

        public StatisticsController(IStatisticsService _statisticsService)
        {
            statisticsService = _statisticsService;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(StatisticsModel))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Statistics()
        {
            var model = await statisticsService.Statistics();
            return Ok(model);
        }
    }
}
