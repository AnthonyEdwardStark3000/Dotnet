using Microsoft.AspNetCore.Mvc;
using NLog;
namespace ConfigureEnvironmentVariables.Controllers{
    public class HomeController:Controller{
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IWebHostEnvironment _webHostEnvironment;

        //Injecting the WebHostEnvironment for accessing the Environmental variables.
        public HomeController(IWebHostEnvironment webHostEnvironment){
            _webHostEnvironment = webHostEnvironment;
        }

        [Route("/")]
        [Route("Index")]
        public IActionResult Index(){
            logger.Info($"Inside the Get request of |{nameof(HomeController)}|and {nameof(Index)} method");
            return View();
        }
    }
}