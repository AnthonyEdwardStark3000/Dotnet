using Microsoft.AspNetCore.Mvc;
using NLog;

namespace Elasticsearch.Controllers{
[Route("api/v1/[controller]")]
    [ApiController]

    public class IndexController : ControllerBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            logger.Error("GET request received for Index action.");
            logger.Debug("GET request received for Index action.");
            return Ok("Log has been made");
        }
    }
}
